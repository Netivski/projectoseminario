
using System;
using System.Collections.Generic;
using EDM.FoundationClasses.FoundationType;

namespace ISEL.Sample.Rtti.Base
{
    public class BaseUserTypeMetadata
    {
    
      protected BaseUserTypeMetadata() { }
      
      
        public static IUserType<string> horaInicioCalendario = new UserType<string>(5, 0, 0, "[0-9]{2}:[0-9]{2}", null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> horaFimCalendario = new UserType<string>(5, 0, 0, "[0-9]{2}:[0-9]{2}", null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> salaCalendario = new UserType<string>(10, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomeDocente = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomeDisciplina = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomeTurma = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomeCurso = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<int> numeroDocente = new UserType<int>(0, 0, 0, null, null, null, new NullableType<int>(1), new NullableType<int>(99999), null, 0, null, null);
  
        public static IUserType<int> anoAno = new UserType<int>(0, 0, 0, null, null, new NullableType<int>(2010), null, new NullableType<int>(2070), null, 0, null, null);
  
        public static IUserType<string> semestreAno = new UserType<string>(10, 0, 0, null, new List<string> {"Inverno", "Verao"}, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomePerson = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomeBlog = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> namePost = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> contentComment = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> createPost = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> createComment = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<int> identificador = new UserType<int>(0, 0, 0, null, null, null, null, new NullableType<int>(5000), null, 0, null, null);
  
        public static IUserType<string> nomeArtista = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> pais = new UserType<string>(0, 0, 3, "[A-Z]{3}", null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> tituloAlbum = new UserType<string>(0, 0, 100, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> dataEdicaoLP = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> DtLancamentoEP = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> generoMusical = new UserType<string>(0, 0, 0, null, new List<string> {"Rock", "Pop", "Reggae", "Blues", "Jazz", "Classica"}, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomeMusica = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> tempoMusica = new UserType<string>(0, 0, 0, "[0-9]{2}:[0-9]{2}", null, null, null, null, null, 0, null, null);
  
        public static IUserType<int> anoColectanea = new UserType<int>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> patrocinadorColectanea = new UserType<string>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomeEditor = new UserType<string>(0, 0, 50, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> tipoAlbum = new UserType<string>(0, 0, 0, null, new List<string> {"LP", "EP"}, null, null, null, null, 0, null, null);
  
        public static IUserType<int> encomendaQtd = new UserType<int>(0, 0, 0, null, null, new NullableType<int>(1), null, new NullableType<int>(100), null, 0, null, null);
  
        public static IUserType<string> canalVendas = new UserType<string>(0, 0, 0, null, new List<string> {"LOJA", "WEB"}, null, null, null, null, 0, null, null);
  
        public static IUserType<int> idCliente = new UserType<int>(0, 0, 0, null, null, null, new NullableType<int>(0), new NullableType<int>(9999999), null, 0, null, null);
  
        public static IUserType<string> idEncomenda = new UserType<string>(20, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> estadoEncomenda = new UserType<string>(0, 0, 0, null, new List<string> {"Registada", "Tramitada", "Esgotada", "Enviada", "Anulada", "Cancelada", "Concluida"}, null, null, null, null, 0, null, null);
  
        public static IUserType<string> retornoCancelarEncomenda = new UserType<string>(0, 0, 0, null, new List<string> {"Cancelada", "EstadoInvalido", "PendenteCancelamento"}, null, null, null, null, 0, null, null);
  
        public static IUserType<string> userName = new UserType<string>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> password = new UserType<string>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomeCompleto = new UserType<string>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<DateTime> dtNascimento = new UserType<DateTime>(0, 0, 0, null, null, null, null, null, null, 0, null, null);
  
        public static IUserType<string> retornoAlteracaoPassword = new UserType<string>(0, 0, 0, null, new List<string> {"Sucesso", "UtilizadorInvalido", "UtilizadorBloqueado"}, null, null, null, null, 0, null, null);
  
        public static IUserType<string> nomeLoja = new UserType<string>(100, 0, 0, null, null, null, null, null, null, 0, null, null);
  
    }
}
  