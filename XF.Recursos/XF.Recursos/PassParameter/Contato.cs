using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.Recursos.PassParameter
{
    public class Contato
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Profissao { get; set; }
        public string Pais { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
