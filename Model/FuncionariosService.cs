using LojaOlharDeMenina_WPF.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaOlharDeMenina_WPF.Model
{
    public class FuncionariosService
    {
        //OlharMeninaBDEntities ObjContext;
        //public FuncionariosService()
        //{
        //    ObjContext = new OlharMeninaBDEntities();
        //}

        //public List<FuncionariosDTO> GetAll()
        //{
        //    List<FuncionariosDTO> ObjFuncionariosList = new List<FuncionariosDTO>();
        //    try
        //    {
        //        var ObjQuery = from obj in ObjContext.Funcionarios
        //                       select obj;
        //        foreach (var Funcionarios in ObjQuery)
        //        {
        //            ObjFuncionariosList.Add(new FuncionariosDTO { ID = Funcionarios.ID, Nome = Funcionarios.Nome});
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ObjFuncionariosList;
        //}

        //public bool Add(FuncionariosDTO objNewFuncionarios)
        //{
        //    bool IsAdded = false;

        //    try
        //    {
        //        var ObjFuncionarios = new Funcionarios();
        //        ObjFuncionarios.ID = objNewFuncionarios.ID;
        //        ObjFuncionarios.Nome = objNewFuncionarios.Nome;

        //        ObjContext.Funcionarios.Add(ObjFuncionarios);
        //        var NoOfRowsAffected = ObjContext.SaveChanges();
        //        IsAdded = NoOfRowsAffected > 0;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }

        //    return IsAdded;
        //}

        //public bool Update(FuncionariosDTO objFuncionariosToUpdate)
        //{
        //    bool IsUpdated = false;

        //    try
        //    {
        //        var ObjFuncionarios = ObjContext.Funcionarios.Find(objFuncionariosToUpdate.ID);
        //        ObjFuncionarios.Nome = objFuncionariosToUpdate.Nome;
        //        var NoOfRowsAffected = ObjContext.SaveChanges();
        //        IsUpdated = NoOfRowsAffected > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return IsUpdated;
        //}

        //public bool Delete(int ID)
        //{
        //    bool IsDeleted = false;
        //    try
        //    {
        //        var ObjFuncionariosToDelete = ObjContext.Funcionarios.Find(ID);
        //        ObjContext.Funcionarios.Remove(ObjFuncionariosToDelete);
        //        var NoOfRowsAffected = ObjContext.SaveChanges();
        //        IsDeleted = NoOfRowsAffected > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return IsDeleted;
        //}

        //public FuncionariosDTO Search(int ID)
        //{
        //    FuncionariosDTO ObjFuncionarios = null;

        //    try
        //    {
        //        var ObjFuncionariosToFind = ObjContext.Funcionarios.Find(ID);
        //        if (ObjFuncionariosToFind != null)
        //        {
        //            ObjFuncionarios = new FuncionariosDTO()
        //            {
        //                ID = ObjFuncionariosToFind.ID,
        //                Nome = ObjFuncionariosToFind.Nome
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ObjFuncionarios;
        //}
    }
}