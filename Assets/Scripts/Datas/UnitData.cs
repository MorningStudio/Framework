using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class UnitData
{
  [SerializeField]
  int id;
  public int Id { get {return id; } set { id = value;} }
  
  [SerializeField]
  string name;
  public string Name { get {return name; } set { name = value;} }
  
  [SerializeField]
  int hp;
  public int Hp { get {return hp; } set { hp = value;} }
  
  [SerializeField]
  int mp;
  public int Mp { get {return mp; } set { mp = value;} }
  
  [SerializeField]
  float speed;
  public float Speed { get {return speed; } set { speed = value;} }
  
  [SerializeField]
  int atk;
  public int Atk { get {return atk; } set { atk = value;} }
  
  [SerializeField]
  int[] intlist = new int[0];
  public int[] Intlist { get {return intlist; } set { intlist = value;} }
  
}