using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace centro_relativo
{
	public interface IDibujable
	{
		void Mov_Centroide(float X,float Y, float Z);
		void Cargar_Buffer();
		void Dibujar();
		List<uint> GetIndices();
		List<Vector3> GetVertices();

	}
}

