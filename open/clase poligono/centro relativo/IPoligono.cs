using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace centro_relativo
{
	public interface IPoligono
	{
		
		float[] GetVertices { get; }
		uint[] GetIndices { get; }
		float[] GetCentroide { get; }
	}
}

