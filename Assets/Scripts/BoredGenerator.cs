using UnityEngine;
using UnityEngine.Serialization;

// poate e checkers
public class BoredGenerator : MonoBehaviour
{
    [FormerlySerializedAs("niggaTile")] [SerializeField]
    private Tile blackTile;

    [SerializeField] private Tile whiteTile;

    [FormerlySerializedAs("niggaPiece")] [SerializeField]
    private Piece blackPiece;

    [SerializeField] private Piece whitePiece;

    private readonly Tile[,] _tiles = new Tile[8, 8];

    private void Start()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        GenerateTiles();
        GeneratePieces();
    }

    private void GeneratePieces()
    {
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                if (i % 2 == 0)
                {
                    if (j % 2 == 0)
                    {
                        var piece = Instantiate(whitePiece, new Vector3(j, 0, i), Quaternion.identity);
                        piece.CurrentTile = _tiles[j, i];
                    }
                }
                else
                {
                    if (j % 2 != 0)
                    {
                        var piece = Instantiate(whitePiece, new Vector3(j, 0, i), Quaternion.identity);
                        piece.CurrentTile = _tiles[j, i];
                    }
                }
            }
        }

        for (var i = 5; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                if (i % 2 == 0)
                {
                    if (j % 2 == 0)
                    {
                        var piece = Instantiate(blackPiece, new Vector3(j, 0, i), Quaternion.identity);
                        piece.CurrentTile = _tiles[j, i];
                    }
                }
                else
                {
                    if (j % 2 != 0)
                    {
                        var piece = Instantiate(blackPiece, new Vector3(j, 0, i), Quaternion.identity);
                        piece.CurrentTile = _tiles[j, i];
                    }
                }
            }
        }
    }

    private void GenerateTiles()
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                Tile tilePrefab;

                if (i % 2 == 0)
                {
                    if (j % 2 == 0)
                    {
                        tilePrefab = blackTile;
                    }
                    else
                    {
                        tilePrefab = whiteTile;
                    }
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        tilePrefab = whiteTile;
                    }
                    else
                    {
                        tilePrefab = blackTile;
                    }
                }

                var tileInstance = Instantiate(tilePrefab, new Vector3(i, 0, j), Quaternion.identity);
                _tiles[i, j] = tileInstance;
            }
        }
    }
}