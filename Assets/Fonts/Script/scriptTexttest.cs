using UnityEngine;
using System.Collections;

public class scriptTexttest : MonoBehaviour 
{
	public GUIText fontTest;
	
	void OnGUI () 
	{
		fontTest.text = "☺☻♥♦♣♠•◘○◙♂♀♪♫☼►◄↕‼▬↨↑↓→←\n" + "∟↔▲▼!#$%&'()*+,-./0123456789:;<=>?\n"
			+ "@ABCDEFGHIJKLMNOPQRSTUVWXYZ\n`abcdefghijklmnopqrstuvwxyz\nîìÄÅÉæÆôöòûùÿÖÜ¢£¥ƒáíóúñÑªº¿¬½¼¡«\n "
				+ "»░▒▓│┤╣║╗┐└┴┬├─┼╚╔╩╦╣║╗•§©®¶" + "\nThanks for using fonts from JazzCreates2015©.";
	}	
}