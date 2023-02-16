namespace Tetris.Core
{
    public class OBlock : Block
    {
        public override int Id => 1;

        private readonly Position[][] _tiles = new Position[][]
        {
            new Position[]{new Position(0,0),new Position(0,1), new Position(1,0), new Position(1,1) }
        };

        protected override Position StartOffset => new Position(0, 4);

        protected override Position[][] Tiles => _tiles;
    }
}
