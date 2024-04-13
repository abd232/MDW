using Models;
namespace MDW.Data
{
    public class DrugData
    {
       public List<Drug> Data;    
    }
    public class Root
    {
        public List<Drug> Data { get; set; }
    }
}
