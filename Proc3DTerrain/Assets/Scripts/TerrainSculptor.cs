using UnityEngine;
using System.Collections;

public class TerrainSculptor : MonoBehaviour {

	/* The 2D grid represented in a 1D array for simplicity. */
	private int [] grid;
	
	/* The dimensions of the grid. */
	// TODO: Have this parameters come from the user input on the screen.
	public int GRID_WIDTH = 5;
	public int GRID_HEIGHT = 5;
	
	/* The prefab that represents the smallest part of a terrain. This will be instantiated multiple times in the grid. */
	public Transform TerrainPartPrefab;
	
	/* The total number of cells in the grid. (GRID_WIDTH * GRID_HEIGHT) */
	private int CELL_COUNT;
	
	void Start () {
		CELL_COUNT = GRID_WIDTH * GRID_HEIGHT;
		
		grid = GenerateInitialPopulation();
		
		CreateTerrain(grid);
	}
	
	void Update () {
	
	}
	
	private int [] GenerateInitialPopulation(){
		
		int [] grid = new int[CELL_COUNT];
		
		for(int i=0; i<CELL_COUNT;i++){
			grid[i] = 1;
		}
		
		return grid;
	}
	
	private void CreateTerrain(int[] grid){
		Transform terrainPart;
		Vector3 terrainPosition;
		int x, y;

		for(int i=0; i<CELL_COUNT; i++){
			if(grid[i] == 1)
			{
				x = i % GRID_WIDTH;
				y = i / GRID_WIDTH;
				terrainPosition = new Vector3(x * TerrainPartPrefab.localScale.x, 0, y * TerrainPartPrefab.localScale.z);
				GameObject.Instantiate(TerrainPartPrefab, terrainPosition, Quaternion.identity);
			}
		}
		
	}
}
