using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carre : Piece {
	private int _rotpos = 1;
	private void Rotate(int[] pos){
		_rotpos *= -1;
	}
	public override void Activate() {
		pos[0] = 196;
		pos[1] = 195;
		pos[2] = 186;
		pos[3] = 185;
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
		pos[0] = 197;
		pos[1] = 196;
		pos[2] = 195;
		pos[3] = 194;
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
		pos[0] = 196;
		pos[1] = 186;
		pos[2] = 185;
		pos[3] = 184;
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
		pos[0] = 197;
		pos[1] = 196;
		pos[2] = 186;
		pos[3] = 185;
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
		pos[0] = 187;
		pos[1] = 186;
		pos[2] = 196;
		pos[3] = 195;
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
		pos[0] = 198;
		pos[1] = 187;
		pos[2] = 186;
		pos[3] = 185;
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
		pos[0] = 197;
		pos[1] = 196;
		pos[2] = 195;
		pos[3] = 185;
	}
}

public abstract class Piece {
	
	private int[] _pos;
	public int[] pos { get { return _pos; } set {_pos = value;}}
	public abstract void Activate();
	
	public Piece (){
		this._pos = new int[] { -1, -1, -1, -1 };
	}

	public void Descend() {
		_pos[0] -= 10;
		_pos[1] -= 10;
		_pos[2] -= 10;
		_pos[3] -= 10;
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
