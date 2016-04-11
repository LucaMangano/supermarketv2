using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class save : MonoBehaviour {

	public string fileName;
	Dropdown d;
	public List<string> fileNameList;

	void Start(){
		LoadFileNames ();
		UpdateDropdownList ();
	}

	public void LoadFileNames(){
		fileNameList = new List<string> ();
		string[] names = GetFileNames ();
		foreach (string name in names) {
			fileNameList.Add (name);
		}
	}

	public void UpdateDropdownList(){
		d = GameObject.Find ("Dropdown").GetComponent<Dropdown> ();
		List<string> temp = new List<string> ();
		foreach (var p in d.options) {
			temp.Add(p.text);
		}
		foreach (string name in fileNameList) {
			if (temp.Contains (name)) {

			} else {
				Dropdown.OptionData option = new Dropdown.OptionData ();
				option.text = name;
				d.options.Add (option);
			}

		}
	}

	private static string[] GetFileNames()
	{
		string[] files = Directory.GetFiles("Assets/Savings/", "*.txt");
		for(int i = 0; i < files.Length; i++)
			files[i] = Path.GetFileNameWithoutExtension(files[i]);
		return files;
	}

	public void Read()
	{
		string fn = fileNameList[d.value];
		List<string> texttoread = new List<string> ();
		string curline;
		System.IO.StreamReader file = new System.IO.StreamReader("Assets/Savings/"+fn+".txt");
		while((curline = file.ReadLine()) != null)
		{
			texttoread.Add(curline);
		}

		GameObject scripts = GameObject.Find ("scripts");
		scripts.GetComponent<createShelf>().loadShelf (texttoread);

	}

	public void Write()
	{
		
		List<string> texttowrite = new List<string> ();
		for(int i = 0; i <= 24; i++){
			for (int l = 0; l <= 12; l++) {							//number of items
				if (GameObject.Find ("placed" + i + "/" + l)) {
					print (i + " " + l);
					texttowrite.Add (i.ToString() + "/" + l.ToString ());
				}
			}
		}

		System.IO.StreamWriter file2 = new System.IO.StreamWriter("Assets/Savings/"+fileName+".txt");
		foreach(string i in texttowrite)
		{
			file2.WriteLine(i.ToString());
		}
		file2.Close();
		GetFileNames ();
		UpdateDropdownList ();
	}	

	public void changeName(string name){
		fileName = name;
	}
}
