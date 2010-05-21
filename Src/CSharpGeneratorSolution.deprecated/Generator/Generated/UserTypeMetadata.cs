
using System;
using EDM.FoundationClasses.FoundationType;

namespace GenRtti
{
  public static class UserTypeMetadata
  {
    
    public static IUserType<int> positiveInt = new UserType<int>(0, 0, 0, null, null, 0, 0, 0, 0, 0, null, null);
  
    public static IUserType<string> nameString = new UserType<string>(34, 0, 0, null, null, 0, 0, 0, 0, 0, null, null);
  
    public static IUserType<datetime> nascimentoDate = new UserType<datetime>(0, 0, 0, null, null, 0, 0, 0, 0, 0, null, null);
  
    public static IUserType<int> iselNumAluno = new UserType<int>(0, 0, 0, null, null, 0, 0, 0, 0, 0, null, null);
  
    public static IUserType<int> iselNumDocente = new UserType<int>(0, 0, 0, null, null, 0, 0, 0, 0, 0, null, null);
  
    public static IUserType<int> iselCodDepartamento = new UserType<int>(0, 0, 0, null, null, 0, 0, 0, 0, 0, null, null);
  
    public static IUserType<string> iselNomeDepartamento = new UserType<string>(0, 0, 0, null, null, 0, 0, 0, 0, 0, null, null);
  
    public static IUserType<int> iselCodCurso = new UserType<int>(0, 0, 0, null, null, 0, 0, 0, 0, 0, 6, null);
  
    public static IUserType<string> iselNomeCurso = new UserType<string>(0, 0, 0, null, null, 0, 0, 0, 0, 0, null, null);
  
    public static IUserType<int> anoEscolar = new UserType<int>(0, 0, 0, "[0-9]{4}", null, 0, 0, 0, 0, 0, null, null);
  
    private List<String> listOf_tipoSemestre = new List<String>(2);
    
    listOf_tipoSemestre.Add("Inverno");
  
    listOf_tipoSemestre.Add("Verão");
  
    public static IUserType<string> tipoSemestre = new UserType<string>(0, 0, 0, null, listOf_tipoSemestre, 0, 0, 0, 0, 0, null, null);
  
    public static IUserType<datetime> inicioSemestre = new UserType<datetime>(0, 0, 0, null, null, 0, 0, 0, 0, 0, null, null);
  
    public static IUserType<datetime> fimSemestre = new UserType<datetime>(0, 0, 0, null, null, 0, 0, 0, 0, 0, null, null);
  
  }
}
  