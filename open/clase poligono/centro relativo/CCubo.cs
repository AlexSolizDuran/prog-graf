using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace centro_relativo
{
    internal class CCubo : IDibujable
    {
        private List<CTriangulo> _TrianguloList = [];
        private CObjeto cubo;

        public CCubo(float X, float Y, float Z)
        {
            // Cara frontal (plano Z constante)
            _TrianguloList.Add(new CTriangulo(
             0.0f, 0.0f, 0.0f,
             X, 0.0f, 0.0f,
             X, Y, 0.0f));

            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,
                X, Y, 0.0f,
                0.0f, Y, 0.0f));

            // Cara trasera (plano Z constante)
            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, Z,
                X, 0.0f, Z,
                X, Y, Z));

            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, Z,
                X, Y, Z,
                0.0f, Y, Z));

            // Cara superior (plano Y constante)
            _TrianguloList.Add(new CTriangulo(
                0.0f, Y, 0.0f,
                X, Y, 0.0f,
                X, Y, Z));

            _TrianguloList.Add(new CTriangulo(
                0.0f, Y, 0.0f,
                X, Y, Z,
                0.0f, Y, Z));

            // Cara inferior (plano Y constante)
            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,
                X, 0.0f, 0.0f,
                X, 0.0f, Z));

            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,
                X, 0.0f, Z,
                0.0f, 0.0f, Z));

            // Cara derecha (plano X constante)
            _TrianguloList.Add(new CTriangulo(
                X, 0.0f, 0.0f,
                X, Y, 0.0f,
                X, Y, Z));

            _TrianguloList.Add(new CTriangulo(
                X, 0.0f, 0.0f,
                X, Y, Z,
                X, 0.0f, Z));

            // Cara izquierda (plano X constante)
            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,
                0.0f, Y, 0.0f,
                0.0f, Y, Z));

            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,
                0.0f, Y, Z,
                0.0f, 0.0f, Z));

            cubo = new CObjeto(_TrianguloList);
        }

        public void Mov_Centroide(float X, float Y, float Z)
        {
            cubo.Mov_Centroide(X,Y,Z);
        }

        public void Cargar_Buffer()
        {
            cubo.Cargar_Buffer();
        }

        public void Dibujar()
        {
            cubo.Dibujar();
        }

        public List<uint> GetIndices()
        {
            return cubo.GetIndices();
        }

        public List<Vector3> GetVertices()
        {
            return cubo.GetVertices();
        }

        public Vector3 GetCentroide()
        {
            return cubo.GetCentroide();
        }
    }
}
