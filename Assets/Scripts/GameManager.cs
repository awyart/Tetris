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

	private void Start () {
		_layout = GameObject.FindObjectOfType<Layout>();
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
		if (Input.GetAxisRaw("Horizontal") == -1)
			MoveG();
		if (Input.GetAxisRaw("Horizontal") == 1)
			MoveD();
		if (Input.GetAxisRaw("Vertical") == -1){
			while (DescendUnit() == true){}
			changePiece();
		}
	}

	private Piece NewPiece(){
		int _type;
		float rdm = Random.value;

		_type = (int)Mathf.Round(rdm * 8f - .51f);
		Debug.Log(_type);
		if (_type == 0)
			return new Carre();
		else if (_type == 1)
			return new Ligne();
		else if (_type == 2)
			return new T();
		else if (_type == 3)
			return new Z();
		else if (_type == 4)
			return new N();
		else if (_type == 5)
			return new L();	
		return new OL();	
	}

	private bool DescendUnit(){
		Piece tmp;

		tmp = _activ;
		tmp.Descend();
		if (check_pos(tmp.pos, _activ.pos) == true)
		{
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
		Material _material = (Material)Resources.Load("GREY", typeof(Material));
		int 	iter = 0;

		while (iter < 4){
			_layout[_activ.pos[iter]].GetComponent<Renderer>().material = _material;
			iter++;
		}
		//_layout[_activ.pos[0]].GetComponent<Renderer>().material = Resources.Load("GREY", typeof(Material));
		//_layout[_activ.pos[1]].GetComponent<GameObject>().renderer.material = Resources.Load("GREY", typeof(Material));
		//_layout[_activ.pos[2]].GetComponent<GameObject>().renderer.material = Resources.Load("GREY", typeof(Material));
		//_layout[_activ.pos[3]].GetComponent<GameObject>().renderer.material = Resources.Load("GREY", typeof(Material));
	}

	private void setactive(Piece pce){
		if (pce == null)
			Debug.Log("C null");
		pce.Activate();
	}

	private void checkline(){
		int line = 0;
		int col = 0;
		int count = 0;

		while (line < 20){
			col = 0;
			while (_layout[line * 10 + col].GetComponent<Renderer>().material == (Material)Resources.Load("GREY", typeof(Material))){
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
				_layout[iter].GetComponent<Renderer>().material = (Material)Resources.Load("NONE", typeof(Material));
			else
				_layout[iter].GetComponent<Renderer>().material = _layout[iter + 10].GetComponent<Renderer>().material;	
			iter++;
		}

	}

	private bool check_pos(int[] pos, int[] init){
		int iter;

		iter = -1;
		foreach(int a in pos){
			if (_layout[a].GetComponent<Renderer>().material == (Material)Resources.Load("GREY", typeof(Material)))
				return (false);
		}
		while (++iter < 4){
			if (_layout[pos[iter]].GetComponent<Renderer>().material == (Material)Resources.Load("NONE", typeof(Material)) || pos[iter] % 10 != init[iter] % 10)
				return (false);
		}
		return(true);
	}

	private bool MoveD(){
		Piece tmp;

		tmp = _activ;
		tmp.Droite();
		if (check_pos(tmp.pos, _activ.pos) == true){
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
			_activ.Gauche();
			return (true);
		}
		return (false);
	}
}
