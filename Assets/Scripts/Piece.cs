using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carre : Piece {
	private int _rotpos = 1;
	private void Rotate(int[] pos){
		_rotpos *= -1;
	}
	public override void Activate() {
		pos[0] = 4;
		pos[1] = 5;
		pos[2] = 14;
		pos[3] = 15;
	}
}

public class Ligne : Piece {
	private int _rotpos = 1;
	private void Rotate(int[] pos){
		pos[0] = pos[0] + 9 * _rotpos;
		pos[2] = pos[2] - 9 * _rotpos;
		pos[3] = pos[3] - 18 * _rotpos;
		_rotpos *= -1;
	}
	public override void Activate() {
		pos[0] = 3;
		pos[1] = 4;
		pos[2] = 5;
		pos[3] = 6;
	}
}

public class T : Piece {
	private int _rotpos = 0;
	private int[] offset = {10, 1, -10, 1};
	private void Rotate(int[] pos){
 		pos[3] = pos[0];
		pos[0] = pos[1];
		pos[1] = pos[2] + offset[_rotpos];
		_rotpos = (_rotpos + 1) % 4;
	}

	public override void Activate() {
		pos[0] = 4;
		pos[1] = 14;
		pos[2] = 15;
		pos[3] = 16;
	}
}

public class Z : Piece {
	private int _rotpos = 1;
	private void Rotate(int[] pos){
		pos[0] = pos[0] + 2 *_rotpos;
		pos[1] = pos[3];
		pos[3] = pos[3] + 9 * _rotpos;
		_rotpos *= -1;
	}

	public override void Activate() {
		pos[0] = 3;
		pos[1] = 4;
		pos[2] = 14;
		pos[3] = 15;
	}

}

public class N : Piece {
	private int _rotpos = 1;
	private void Rotate(int[] pos){
		pos[0] = pos[0] + 2 *_rotpos;
		pos[3] = pos[1];
		pos[1] = pos[1] + 9 * _rotpos;
		_rotpos *= -1;
	}

	public override void Activate() {
		pos[0] = 13;
		pos[1] = 14;
		pos[2] = 4;
		pos[3] = 5;
	}
}

public class L : Piece {
	private int _rotpos = 1;
	private int[][] offset = new int[4][]
	{
		new int[] {20, -9, 0, 9},
		new int[] {-2, -11, 0, -11},
		new int[] {-20, 9, 0, -9},
		new int[] {2, 11, 0, 11}
	};
	
	private void Rotate(int[] pos){
		pos[0] += offset[_rotpos][0];
		pos[1] += offset[_rotpos][1];
		pos[3] += offset[_rotpos][3];
		_rotpos = (_rotpos + 1) % 4;
	}
	public override void Activate() {
		pos[0] = 5;
		pos[1] = 13;
		pos[2] = 14;
		pos[3] = 15;
	}

}

public class OL : Piece {
	private int _rotpos = 1;
	private int[][] offset = new int[4][]
	{
		new int[] {-2, -9, 0, 9},
		new int[] {-20, -11, 0, -11},
		new int[] {2, 9, 0, -9},
		new int[] {20, 11, 0, 11}
	};
	
	private void Rotate(int[] pos){
		pos[0] += offset[_rotpos][0];
		pos[1] += offset[_rotpos][1];
		pos[3] += offset[_rotpos][3];
		_rotpos = (_rotpos + 1) % 4;
	}

	public override void Activate() {
		pos[0] = 3;
		pos[1] = 4;
		pos[2] = 5;
		pos[3] = 15;
	}
}

public abstract class Piece {
	
	private int[] _pos;
	public int[] pos { get { return _pos; } set {_pos = value;}}
	public abstract void Activate();
	
	private void Start() {
		_pos[0] = -1;
		_pos[1] = -1;
		_pos[2] = -1;
		_pos[3] = -1;
	}

	public void Descend() {
		_pos[0] += 10;
		_pos[1] += 10;
		_pos[2] += 10;
		_pos[3] += 10;
	}

	public void Droite() {
		_pos[1] += 1;
		_pos[2] += 1;
		_pos[3] += 1;
		_pos[0] += 1;
	}

	public void Gauche() {
		_pos[1] -= 1;
		_pos[2] -= 1;
		_pos[3] -= 1;
		_pos[0] -= 1;
	}
}
