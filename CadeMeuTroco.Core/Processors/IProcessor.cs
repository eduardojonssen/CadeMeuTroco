using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeMeuTroco.Core.Processors {
    public interface IProcessor {

        /// <summary>
        /// Retorna a lista de valores disponíveis
        /// </summary>
        /// <returns></returns>
        List<int> GetAvailableValues();

        /// <summary>
        /// Retorna o nome
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Retorna um dicionario com a quantidade de moedas ou notas de cada tipo que serão retornadas
        /// </summary>
        /// <param name="changeAmountInCents"></param>
        /// <returns></returns>
        Dictionary<int, long> CalculateChange(long changeAmountInCents);

    }
}
