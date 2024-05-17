using UnityEngine;

public class PieceSelector : MonoBehaviour
{
    [SerializeField] private Material selectedMaterial;

    private Piece _selectedPiece;
    private Material _previousMaterial;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                var piece = hit.collider.GetComponent<Piece>();
                var tile = hit.collider.GetComponent<Tile>();

                if (piece)
                {
                    if (_selectedPiece == piece) // Deselect the piece if it's already selected
                    {
                        _selectedPiece.gameObject.GetComponent<Renderer>().material = _previousMaterial;
                        _selectedPiece = null;
                    }
                    else // Select a new piece
                    {
                        if (_selectedPiece)
                        {
                            _selectedPiece.gameObject.GetComponent<Renderer>().material = _previousMaterial;
                        }

                        _selectedPiece = piece;
                        _previousMaterial = _selectedPiece.gameObject.GetComponent<Renderer>().material;

                        _selectedPiece.gameObject.GetComponent<Renderer>().material = selectedMaterial;
                    }
                }
                else if (tile && _selectedPiece)
                {
                    // Check if the target position is diagonal to the current position

                    var dx = Mathf.Abs(_selectedPiece.CurrentTile.transform.position.x - tile.transform.position.x);
                    var dz = Mathf.Abs(_selectedPiece.CurrentTile.transform.position.z - tile.transform.position.z);

                    if (dx == 1 && dz == 1) // The target position is diagonal
                    {
                        _selectedPiece.transform.position = tile.transform.position;
                        _selectedPiece.CurrentTile = tile;
                    }
                }
            }
        }
    }
}