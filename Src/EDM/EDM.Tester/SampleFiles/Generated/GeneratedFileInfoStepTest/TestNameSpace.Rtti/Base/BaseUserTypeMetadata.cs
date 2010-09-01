
using System;
using System.Collections.Generic;
using EDM.FoundationClasses.FoundationType;

namespace .Base
{
    public class BaseUserTypeMetadata
    {
    
      protected BaseUserTypeMetadata() { }
      
      
        public static IUserType<int> identificador = new UserType<int>(0, 0, 0, null, null, null, null, new NullableType<int>(5000), null, 0, null, null);
  
        public static IUserType<string> nomeArtista = new UserType<string>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> pais = new UserType<string>(0, 0, 3, "[A-Z]{3}", null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> tituloAlbum = new UserType<string>(0, 0, 100, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> dataEdicaoLP = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> generoMusical = new UserType<string>(0, 0, 0, null, new List<string> {"Rock", "Pop", "Reggae", "Blues", "Jazz", "Classica"}, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomeMusica = new UserType<string>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> tempoMusica = new UserType<string>(0, 0, 0, "[0-9]{2}:[0-9]{2}", null, null, null, null, null, 0, null, null);
  
        public static IUserType<int> anoColectanea = new UserType<int>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> patrocinadorColectanea = new UserType<string>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomeEditor = new UserType<string>(0, 0, 50, null, null, null, null, null, null, 0, null, null);
  
    }
}
  