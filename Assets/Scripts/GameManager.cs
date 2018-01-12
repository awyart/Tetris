using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum t_color {
	NONE,
	BLUE,
	YELLOW,
	GREEN,
	GREY
}

enum t_type {
	CARRE,
	LIGNE, 
	T,
	Z,
	N,
	L,
	OL
}

public class GameManager : MonoBehaviour {
	
	private Piece _activ;
	private Piece _idle;
	private Layout _layout;
	// private Material m_none;
	// private Material m_color;
	// private Material m_grey; 


	private void Awake () {
		int iter = 0;

		_layout = GameObject.FindObjectOfType<Layout>();
		while (iter < 200){
			_layout[iter].GetComponent<Renderer>().material.color = Color.yellow;
			iter++;
		}
		_activ = NewPiece();
		setactive(_activ);
		_idle = NewPiece();
		StartCoroutine(Descente());
	}

	private IEnumerator Descente(){
		while (true){
			yield return new WaitForSeconds(1f);
			if (DescendUnit() == false){
				changePiece();
			}
		}
	}

	private void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			MoveG();
		if (Input.GetKeyDown(KeyCode.RightArrow))
			MoveD();
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			while (DescendUnit() == true){}
			changePiece();
		}
	}

	private Piece NewPiece(){
		int _type;
		float rdm = Random.value;
		Piece tmp;

		_type = (int)Mathf.Round(rdm * 8f - .51f);
		Debug.Log(_type);
		if (_type == 0)
			tmp = new Carre();
		else if (_type == 1)
			tmp = new Ligne();
		else if (_type == 2)
			tmp = new T();
		else if (_type == 3)
			tmp = new Z();
		else if (_type == 4)
			tmp = new N();
		else if (_type == 5)
			tmp = new L();	
		else
			tmp = new OL();
		return tmp;	
	}

	private bool DescendUnit(){
		Piece tmp;

		tmp = _activ;
		tmp.Descend();
		if (check_pos(tmp.pos, _activ.pos) == true)
		{
			_layout.setcolor(_activ.pos, tmp.pos, Color.blue);
			_activ.Descend();
			return (true);
		}
		return(false);
	}

	private void changePiece(){
		end(_activ);
		checkline();
		_activ = _idle;
		setactive(_activ);
		_idle = NewPiece();
	}

	private void end(Piece pce){
		int 	iter = 0;

		while (iter < 4){
			_layout[pce.pos[iter]].GetComponent<Renderer>().material.color = Color.grey;
			iter++;
		}
	}

	private void setactive(Piece pce){
		pce.Activate();
		_layout.hsetcolor(pce.pos, Color.blue);
	}

	private void checkline(){
		int line = 0;
		int col = 0;
		int count = 0;

		while (line < 20){
			col = 0;
			while (_layout[line * 10 + col].GetComponent<Renderer>().material.color == Color.grey){
				if (col == 9){
					deleteLine(line);
					count++;
					line--;
					break ; 
				}
				col++;
			}
			line++;
		}
	}

	private void  deleteLine(int line){
		int iter;

		iter = line * 10;
		while (_layout[iter]){
			if (iter < 190)
				_layout[iter].GetComponent<Renderer>().material.color = Color.white;
			else
				_layout[iter].GetComponent<Renderer>().material.color = _layout[iter + 10].GetComponent<Renderer>().material.color;	
			iter++;
		}

	}

	private bool check_pos(int[] pos, int[] init){
		int iter;

		iter = -1;
		foreach(int a in pos){
			if (a < 0 || _layout[a].GetComponent<Renderer>().material.color == Color.red)
				return (false);
		}
		while (++iter < 4){
			if (_layout[pos[iter]].GetComponent<Renderer>().material.color == Color.white)
		 		return (false);
		}
		return (true);
	}

	private bool MoveD(){
		Piece tmp;

		tmp = _activ;
		tmp.Droite();
		if (check_pos(tmp.pos, _activ.pos) == true){
			_layout.setcolor(_activ.pos, tmp.pos, Color.blue);
			_activ.Droite();
			return (true);
		}
		return(false);
	}

	private bool MoveG(){
		Piece tmp;

		tmp = _activ;
		tmp.Gauche();
		if (check_pos(tmp.pos, _activ.pos) == true){
			_layout.setcolor(_activ.pos, tmp.pos, Color.blue);
			_activ.Gauche();
			return (true);
		}
		return (false);
	}
}
