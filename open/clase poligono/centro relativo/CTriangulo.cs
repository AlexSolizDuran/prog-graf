﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace centro_relativo
{
    internal class CTriangulo :IPoligono 
    {
        private float[] _Vertices;
        private uint[] _Indices;
        private float[] _Centroide;

        public CTriangulo(float X1, float Y1, float Z1,
                          float X2, float Y2, float Z2,
                          float X3, float Y3, float Z3)
        {
            _Vertices = new float[9]
            {
                X1, Y1, Z1,
                X2, Y2, Z2,
                X3, Y3, Z3
            };

            _Indices = new uint[3]
            {
                0, 1, 2
            };

            
            _Centroide = new float[3]
            {
                (X1 + X2 + X3) / 3,
                (Y1 + Y2 + Y3) / 3,
                (Z1 + Z2 + Z3) / 3
            };
        }
        public void Plano_X()
        {
            float X1 = _Vertices[1]; float X2 = _Vertices[4]; float X3 = _Vertices[7];
            _Vertices[2] = _Vertices[0]; _Vertices[5] = _Vertices[3]; _Vertices[8] = _Vertices[6];
            _Vertices[0] = X1; _Vertices[3] = X2; _Vertices[6] = X3; 
        }
        public void Mov_Centroide(float X,float Y, float Z)
        {
            
            _Centroide[0]= X; _Centroide[1]= Y; _Centroide[2]= Z;
            Mov_Vertices(X,Y,Z);
        }

        private void Mov_Vertices(float X, float Y, float Z)
        {

            _Vertices[0] += X; _Vertices[3] += X; _Vertices[6] += X;
            _Vertices[1] += Y; _Vertices[4] += Y; _Vertices[7] += Y;
            _Vertices[2] += Z; _Vertices[5] += Z; _Vertices[8] += Z;
        }

            
        public float[] GetVertices(){ return _Vertices; }
        public uint[] GetIndices() { return _Indices; }
        public float[] GetCentroide() { return _Centroide; }
    }
}
