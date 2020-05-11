using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterCopyTests
{
    public class Copier
    {
        private readonly ISource _source;
        private readonly IDestination _destination;

        public Copier(ISource source, IDestination destination)
        {
            _source = source;
            _destination = destination;
        }

        public void Copy()
        {
            var character = _source.ReadChar();

            while(character != '\n')
            {
                _destination.WriteCharacter(character);
                character = _source.ReadChar();
            }
        }
    }
}
