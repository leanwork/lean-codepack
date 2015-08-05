using System;
using System.Security.Cryptography;

namespace Leanwork.CodePack.Utilities
{
    public class SecureRandom
    {
        private readonly RNGCryptoServiceProvider _rng;
        readonly byte[] _buffer;
        int _bufferFinal;

        public SecureRandom()
            : this(32768)
        {
        }

        public SecureRandom(int lengthBuffer)
        {
            _buffer = new byte[lengthBuffer];
            _rng = new RNGCryptoServiceProvider();
            LoadBuffer();
        }

        private void LoadBuffer()
        {
            var novoArray = new byte[_buffer.Length - _bufferFinal];
            _rng.GetBytes(novoArray);
            Array.Copy(novoArray, 0, _buffer, _bufferFinal, novoArray.Length);
            _bufferFinal = _buffer.Length;
        }

        public uint Next()
        {
            if (_bufferFinal < 4)
            {
                LoadBuffer();
            }

            _bufferFinal -= 4;
            return BitConverter.ToUInt32(_buffer, _bufferFinal);
        }

        public uint Next(int minValue, int maxValue)
        {
            uint numberRandom;
            do
            {
                numberRandom = Next();
            }
            while (numberRandom < minValue || numberRandom >= maxValue);
            return numberRandom;
        }

        public uint Next(int maxValue)
        {
            return Next(0, maxValue);
        }
    }
}
