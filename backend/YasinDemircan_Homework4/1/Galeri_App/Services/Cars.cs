using System;
using System.Linq;

namespace Galeri_App.Car
{
    public class Cars: ICarForSell, ICarForShow, ICarForTest
    {
    string _name;
        public Cars()
        {
            Random rnd = new Random();
            int r = rnd.Next(1,100);
            _name = r.ToString()+" Nolu Araç";

        }

        public string GetName(){
            return _name;
        }
    }
     public interface ICarForShow
    {

        string GetName();
        
    }

    public interface ICarForTest
    {
      
         string GetName();
    }

    public interface ICarForSell
    {
       
         string GetName();
    }

}
