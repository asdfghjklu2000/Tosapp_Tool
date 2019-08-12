using System;
using System.IO;
using System.Security.Cryptography;

namespace Tosapp_Tool
{
    internal abstract class HashAlgorithm : IDisposable, ICryptoTransform
    {
        protected int State;

        private bool disposed;

        protected internal byte[] HashValue;

        protected int HashSizeValue;

        public virtual bool CanReuseTransform
        {
            get
            {
                return true;
            }
        }

        public virtual bool CanTransformMultipleBlocks
        {
            get
            {
                return true;
            }
        }

        public virtual byte[] Hash
        {
            get
            {
                if (this.HashValue == null)
                {
                    throw new CryptographicUnexpectedOperationException("No hash value computed.");
                }
                return this.HashValue;
            }
        }

        public virtual int HashSize
        {
            get
            {
                return this.HashSizeValue;
            }
        }

        public virtual int InputBlockSize
        {
            get
            {
                return 1;
            }
        }

        public virtual int OutputBlockSize
        {
            get
            {
                return 1;
            }
        }

        protected HashAlgorithm()
        {
            this.disposed = false;
        }

        void IDisposable.Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public static HashAlgorithm Create()
        {
            return HashAlgorithm.Create("System.Security.Cryptography.HashAlgorithm");
        }

        public static HashAlgorithm Create(string hashName)
        {
            return (HashAlgorithm)CryptoConfig.CreateFromName(hashName);
        }

        public void Clear()
        {
            this.Dispose(true);
        }

        public byte[] CHH(Stream inputStream)
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException("HashAlgorithm");
            }
            byte[] array = new byte[4096];
            for (int i = inputStream.Read(array, 0, 4096); i > 0; i = inputStream.Read(array, 0, 4096))
            {
                this.HashCore(array, 0, i);
            }
            this.HashValue = this.HashFinal();
            this.Initialize();
            return this.HashValue;
        }

        public byte[] CHH(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            return this.CHH(buffer, 0, buffer.Length);
        }

        public byte[] CHH(byte[] buffer, int offset, int count)
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException("HashAlgorithm");
            }
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "< 0");
            }
            if (count < 0)
            {
                throw new ArgumentException("count", "< 0");
            }
            if (offset > buffer.Length - count)
            {
                throw new ArgumentException("offset + count", "Overflow");
            }
            this.HashCore(buffer, offset, count);
            this.HashValue = this.HashFinal();
            this.Initialize();
            return this.HashValue;
        }

        protected virtual void Dispose(bool disposing)
        {
            this.disposed = true;
        }

        protected abstract void HashCore(byte[] array, int ibStart, int cbSize);

        protected abstract byte[] HashFinal();

        public abstract void Initialize();

        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            if (inputBuffer == null)
            {
                throw new ArgumentNullException("inputBuffer");
            }
            if (inputOffset < 0)
            {
                throw new ArgumentOutOfRangeException("inputOffset", "< 0");
            }
            if (inputCount < 0)
            {
                throw new ArgumentException("inputCount");
            }
            if (inputOffset < 0 || inputOffset > inputBuffer.Length - inputCount)
            {
                throw new ArgumentException("inputBuffer");
            }
            if (outputBuffer != null)
            {
                if (outputOffset < 0)
                {
                    throw new ArgumentOutOfRangeException("outputOffset", "< 0");
                }
                if (outputOffset > outputBuffer.Length - inputCount)
                {
                    throw new ArgumentException("outputOffset + inputCount", "Overflow");
                }
            }
            this.HashCore(inputBuffer, inputOffset, inputCount);
            if (outputBuffer != null)
            {
                Buffer.BlockCopy(inputBuffer, inputOffset, outputBuffer, outputOffset, inputCount);
            }
            return inputCount;
        }

        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            if (inputBuffer == null)
            {
                throw new ArgumentNullException("inputBuffer");
            }
            if (inputCount < 0)
            {
                throw new ArgumentException("inputCount");
            }
            if (inputOffset > inputBuffer.Length - inputCount)
            {
                throw new ArgumentException("inputOffset + inputCount", "Overflow");
            }
            byte[] array = new byte[inputCount];
            Buffer.BlockCopy(inputBuffer, inputOffset, array, 0, inputCount);
            this.HashCore(inputBuffer, inputOffset, inputCount);
            this.HashValue = this.HashFinal();
            this.Initialize();
            return array;
        }
    }
}
