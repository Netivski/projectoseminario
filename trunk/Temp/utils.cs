using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Text;
using EnvDTE;
using EnvDTE80;

namespace dotNails.Util {

    // These are found in <drive>:\Program Files\Microsoft Visual Studio 8\Common7\IDE\ProjectTemplates\
    public struct ProjectType {
        public static string ConsoleApplication = "ConsoleApplication.zip";
        public static string WebApplication = "WebApplication.zip";
        public static string WebService = "WebService.zip";
        public static string ClassLibrary = "ClassLibrary.zip";
        public static string EmptyProject = "EmptyProject.zip";
        public static string WindowsApplication = "WindowsApplication.zip";
        public static string WindowsService = "WindowsService.zip";
    }

    // These are found in <drive>:\Program Files\Microsoft Visual Studio 8\Common7\IDE\ItemTemplates\
    public struct ProjectItemType {
        public static string WebClass = "WebClass.zip";
        public static string WebForm = "WebForm.zip";
        public static string WebuserControl = "WebuserControl.zip";
        public static string WebHtmlPage = "WebHtmlPage.zip";
        public static string WebConfig = "WebConfig.zip";
        public static string GlobalAsax = "GlobalAsax.zip";
        public static string Class = "Class.zip";
        public static string Interface = "Interface.zip";
    }

    public struct ProjectLanguage {
        public static string CSharp = "CSharp";
        public static string VisualBasic = "vbproj";
    }

    sealed class ProjectUtil {
        public static void CreateProject(Solution2 soln, string projType, string projLanguage, string projPath) {
            try {
                string templatePath;

                // Get the project template path
                templatePath = soln.GetProjectTemplate(projType, projLanguage);

                soln.AddFromTemplate(templatePath, projPath, projType, false);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR: " + ex.Message);
            }
        }

		//public static void AddFromFile(Project proj, string filePath)
        //{
        //    ProjectGenerator.AddFromFile(proj, filePath, string.Empty);
        //}


        //public static void AddFromFile(Project proj, string filePath, string fileName)
        //{
        //    ProjectItem projItem = proj.ProjectItems.AddFromFile(filePath);

        //    projItem.Save(fileName);
        //}

        public static void AddFromDirectory(Project proj, string folderPath) {
            ProjectUtil.AddFromDirectory(proj, folderPath, string.Empty);
        }

        public static void AddFromDirectory(Project proj, string folderPath, string destinationName) {
            ProjectItem projItem = proj.ProjectItems.AddFromDirectory(folderPath);

            projItem.Save(destinationName);
        }

        public static void AddFolder(Project proj, string folderName) {
            ProjectItem projItem = proj.ProjectItems.AddFolder(folderName, string.Empty);

            projItem.Save(folderName);
        }

        public static void AddFromTemplate(Project proj, string name, string itemType, string projLanguage) {
            Solution2 soln = (Solution2)proj.DTE.Solution;
            // string templatePath = soln.GetProjectItemTemplate(, projLanguage);

            ProjectItem projItem = proj.ProjectItems.AddFromTemplate(itemType, name);

            // projItem.Save(name);
        }

		public static bool FileExistsInProject(Project project, string relativeFileFolder, string fileName) {
			bool fileExistsInProject = false;
			bool folderExists = true;
			Solution2 soln = (Solution2)project.DTE.Solution;

			try {
				// First, get to the correct folder
				ProjectItems projectFolder = project.ProjectItems;
				
				if (!string.IsNullOrEmpty(relativeFileFolder)) {
					string projectFile = AddInUtil.GetProjectFilePath(project);
					string fullFolderPath = AddInUtil.GetFolderPath(projectFile);

					// Split the relativeFileFolder by the "\"
					string[] splitRelativeFileFolder = relativeFileFolder.Split('\\');
					bool folderFound = false;
					
					// Cycle through the sub folder split to ensure they all exist in the project
					for (int i = 0; i < splitRelativeFileFolder.Length; i++) {
						fullFolderPath = Path.Combine(fullFolderPath, splitRelativeFileFolder[i]);
						folderFound = false;
						// Cycle through the project items to see if there is a folder that matches the new fullFolderPath
						foreach (ProjectItem currentProjItem in projectFolder) {
							// If the folder was found, set the new project item to the current project item
							if (currentProjItem.Name == splitRelativeFileFolder[i]) {
								projectFolder = currentProjItem.ProjectItems;
								folderFound = true;
								break; // Folder is found, no need to search anymore
							}
						}

						if (!folderFound) {
							// We missed this folder, so no need to look for the subsequent folders
							break;
						}
					}

					folderExists = folderFound;
				}

				if (folderExists) {
					// Now, look for the file
					foreach (ProjectItem projItem in projectFolder) {
						if (projItem.Name == fileName) {
							fileExistsInProject = true;
							break;
						}
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}

			return fileExistsInProject;
		}

        /// <summary>
        /// Add a File to a specific project
        /// </summary>
        /// <param name="proj">The project to add the file to</param>
        /// <param name="filePath">Path where the file is located - must be same as where the file will be in the project</param>
		public static void AddFromFile(Project project, string relativeFileFolder, string filePath) {
            Solution2 soln = (Solution2)project.DTE.Solution;

            try {
                ProjectItems projectFolder = project.ProjectItems;
				string projectFile = AddInUtil.GetProjectFilePath(project);
				string fullFolderPath = AddInUtil.GetFolderPath(projectFile);
           		
				// Find out if a subfolder is needed, if so, create it
				if (!string.IsNullOrEmpty(relativeFileFolder)) {
					// Split the relativeFileFolder by the "\"
					string[] splitRelativeFileFolder = relativeFileFolder.Split('\\');

				    // Cycle through the sub folder split and create the folders needed
					for (int i = 0; i < splitRelativeFileFolder.Length; i++) {
						if (!string.IsNullOrEmpty(splitRelativeFileFolder[i])) {
							fullFolderPath = Path.Combine(fullFolderPath, splitRelativeFileFolder[i]);
							projectFolder = FetchProjectItem(splitRelativeFileFolder[i], projectFolder, fullFolderPath);
						}
				    }
				}
                // Add the file to the project folder
                InsertFile(projectFolder, filePath);
            }
			catch (Exception ex) {
                string text = "";
            }
        }

		private static ProjectItems FetchProjectItem(string folderName, ProjectItems projectItems, string fullFolderPath) {

            ProjectItem newProjectItem = null;
			
            // Cycle through the project items to see if there is a folder that matches the name passed into it
            foreach (ProjectItem currentProjItem in projectItems) {

                // If the folder was found, set the new project item to the current project item
                if (currentProjItem.Name == folderName) {
                    newProjectItem = currentProjItem;
                    break; // Folder is found, no need to search anymore
                }
            }
			
			// If the folder was not found, create it
            if (newProjectItem == null) {
				if (!Directory.Exists(fullFolderPath)) {
					//AddFolder creates a new folder under the Project directory
					newProjectItem = projectItems.AddFolder(folderName, Constants.vsProjectItemKindPhysicalFolder);
				}
				else {
					// Adds an existing folder recursively to the project.
					//  Currently, this method adds all files within the folder to the project as well.  I can't use the above method (AddFolder) because it throws an exception
					//  if the folder already exists on disk.  There's a bug submission on the connect site describing this issue that I've "validated" on there, so hopefully they'll 
					//  give us an AddExistingFolder option soon.
					newProjectItem = projectItems.AddFromDirectory(fullFolderPath);
				}
            }

			return newProjectItem.ProjectItems;
        }

        private static void InsertFile(ProjectItems projItems, string filePath) {
            
            // Get the file name
            bool fileExists = false;
            string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);

            // Before inserting the file, make sure it doesnt exists
            foreach (ProjectItem projItem in projItems) {
                if (projItem.Name == fileName) {
					fileExists = true;
					break;
                }
            }

			if (!fileExists) {
				projItems.AddFromFileCopy(filePath);
			}
        }

    }
}

