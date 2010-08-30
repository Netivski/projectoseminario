create database RN_RBAC1;

use RN_RBAC1;

create table USERS( 
  userName varchar(50) NOT NULL
  CONSTRAINT PK_USERS PRIMARY KEY CLUSTERED (userName ASC)
);

insert into USERS( userName )
select 'Nuno.Sousa' union all
select 'Ricardo.Neto' union all
select 'Paulo.Pires' union all
select 'Ricardo.Romao' union all
select 'Rui.Joaquim' union all 
select 'Pedro.Felix' ;

create table ROLES( 
  roleName varchar(50) NOT NULL
  CONSTRAINT PK_ROLES PRIMARY KEY CLUSTERED (roleName ASC)
);

insert into ROLES( roleName )
select 'Docente' union all
select 'Aluno' union all
select 'Guest' union all
select 'Administrator';

create table USER_ASSOCIATIONS(
	userName varchar(50) NOT NULL,
	roleName varchar(50) NOT NULL
	CONSTRAINT PK_UA PRIMARY KEY CLUSTERED (userName, roleName),
	CONSTRAINT FK_UA_USERS FOREIGN KEY (userName) REFERENCES USERS (userName),
	CONSTRAINT FK_UA_ROLES FOREIGN KEY (roleName) REFERENCES ROLES (roleName)
);

insert into USER_ASSOCIATIONS( userName, roleName )
select 'Nuno.Sousa', 'Administrator' union all
select 'Nuno.Sousa', 'Aluno' union all
select 'Ricardo.Neto', 'Administrator' union all
select 'Ricardo.Neto', 'Aluno' union all
select 'Ricardo.Romao', 'Aluno' union all
select 'Rui.Joaquim', 'Docente' union all
select 'Pedro.Felix', 'Docente'; 

create table PERMISSION(
	permissionName varchar(50) NOT NULL
	CONSTRAINT PK_PERMISSION PRIMARY KEY CLUSTERED (permissionName)
);

insert into PERMISSION( permissionName )
select 'Method A' union all
select 'Method B' union all
select 'Method C' union all
select 'Method D';

create table ROLE_ASSOCIATION(
	roleName varchar(50) NOT NULL,
	permissionName varchar(50) NOT NULL
	CONSTRAINT PK_RA PRIMARY KEY CLUSTERED (roleName, permissionName),
	CONSTRAINT FK_ROLE FOREIGN KEY (roleName) REFERENCES ROLES (roleName),
	CONSTRAINT FK_PERMISSION FOREIGN KEY (permissionName) REFERENCES PERMISSION (permissionName)
);

insert into ROLE_ASSOCIATION (roleName, permissionName)
select 'Administrator', 'Method A' union all
select 'Administrator', 'Method B' union all
select 'Administrator', 'Method C' union all
select 'Administrator', 'Method D' union all
select 'Aluno', 'Method A' union all
select 'Aluno', 'Method B' union all
select 'Docente', 'Method C' union all
select 'Docente', 'Method D';

create table ROLE_HIERARCHY(
	seniorRole varchar(50) NOT NULL,
	juniorRole varchar(50) NOT NULL
	CONSTRAINT PK_RH PRIMARY KEY CLUSTERED (seniorRole, juniorRole),
	CONSTRAINT FK_SR FOREIGN KEY (seniorRole) REFERENCES ROLES (roleName),
	CONSTRAINT FK_JR FOREIGN KEY (juniorRole) REFERENCES ROLES (roleName)
);

insert into ROLE_HIERARCHY (seniorRole, juniorRole)
select 'Aluno', 'Guest';

create procedure spGetAllRoles
as
SELECT * FROM ROLES;

create procedure spAddUserToRoles
@user varchar(50),
@role varchar(50)
as
INSERT INTO USER_ASSOCIATIONS 
VALUES(@user, @role);

create procedure spCreateRole
@role varchar(50)
as
INSERT INTO ROLES
VALUES(@role);

create procedure spDeleteRole
@role varchar(50)
as
DELETE FROM ROLES WHERE roleName = @role;

create procedure spDeleteUsersAssociations
@role varchar(50)
as
DELETE FROM USER_ASSOCIATIONS
WHERE roleName = @role;

create procedure spFindUsersInRoles
@role varchar(50),
@user varchar(50)
as
SELECT * FROM USER_ASSOCIATIONS 
WHERE roleName = @role
AND userName LIKE '%' + @user + '%';

create procedure spGetRolesForUser
@user varchar(50)
as
SELECT roleName FROM USER_ASSOCIATIONS
WHERE userName = @user;

create procedure spGetUsersInRole
@role varchar(50)
as
SELECT userName FROM USER_ASSOCIATIONS
WHERE roleName = @role;

create procedure spIsUserInRole
@user varchar(50),
@role varchar(50)
as
SELECT * FROM USER_ASSOCIATIONS
WHERE userName = @user
AND roleName = @role;

create procedure spRemoveUsersFromRoles
@user varchar(50),
@role varchar(50)
as
DELETE FROM USER_ASSOCIATIONS
WHERE userName = @user
AND roleName = @role;

create procedure spRoleExists
@role varchar(50)
as
SELECT * FROM ROLES
WHERE roleName = @role;

create procedure spGetRoleHierarchy
@seniorRole varchar(50)
as
SELECT juniorRole FROM ROLE_HIERARCHY
WHERE seniorRole = @seniorRole;

create procedure spGetRolesWithPermission
@permissionName varchar(50)
as
SELECT roleName FROM ROLE_ASSOCIATION
WHERE permissionName = @permissionName;

CREATE LOGIN testerUser
WITH PASSWORD = 'testerUser';

USE RN_RBAC1;
CREATE USER testerUser FOR LOGIN testerUser
    WITH DEFAULT_SCHEMA = dbo;

GRANT EXECUTE, INSERT, UPDATE, DELETE, SELECT TO testerUser;