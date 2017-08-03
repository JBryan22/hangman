using System.Collections.Generic;
using System;

namespace Hangman.Models
{
  public class Board
  {
    private string _word;
    private char[] _wordList;
    private List<string> _alphabet;
    private List<string> _words;

    private static List<string> _wrongGuessInstances = new List<string> {};
    private static List<string> _rightGuessInstances = new List<string> {};

    public Board()
    {
      _alphabet = new List<string> {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
      _words = new List<string>{"battleship","epicodus","nalgene", "jellyfish", "macintosh", "electrolytes", "exception", "alaska", "steelhead", "developer"};
      Random rnd = new Random();
      _word = _words[rnd.Next(0, _words.Count - 1)];
      _wordList = _word.ToCharArray();
    }

    public static bool CheckValidGuess(string guess)
    {
      if (_alphabet.Contains(guess))
      {
        return true;
      }
      return false;
    }

    public static bool CheckGuess(string guess)
    {
      if (_word.Contains(guess))
      {
        _rightGuessInstances.Add(guess);
        _alphabet.RemoveAt(_alphabet.IndexOf(guess));
        return true;
      }
      else
      {
        _wrongGuessInstances.Add(guess);
        _alphabet.RemoveAt(_alphabet.IndexOf(guess));
        return false;
      }
    }

    public static int CheckWrong()
    {
      return _wrongGuessInstances.Count;
    }

    public static string[] GetWordList()
    {
      return _wordList;
    }

    public static List<string> GetRightGuesses()
    {
      return _rightGuessInstances;
    }

    public static List<string> GetWrongGuesses()
    {
      return _wrongGuessInstances;
    }


  }
}
