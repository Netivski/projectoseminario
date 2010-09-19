
using System;
using EDM.FoundationClasses.Entity;
using EDM.FoundationClasses.FoundationType;
using EDM.FoundationClasses.Persistence.Core;
using ISEL.Sample.Rtti;

namespace ISEL.Sample.Entity
{
  [Serializable]
  public abstract class Pessoa : Domain.PessoaDomain
  {
    public Pessoa () {}
  }
}
  