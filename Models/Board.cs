using System.Collections.Generic;
using System;

namespace Hangman.Models
{
  public class Board
  {
    private string _word;
    private List<char> _alphabet;
    private List<string> _words;

    private static List<Board> _instances = new List<Board>{};

    private List<char> _wrongGuessInstances;
    private List<char> _rightGuessInstances;

    public Board()
    {
      _alphabet = new List<char> {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
      _words = new List<string>{"battleship","epicodus","nalgene", "jellyfish", "macintosh", "electrolytes", "exception", "alaska", "steelhead", "developer"};
      Random rnd = new Random();
      _instances.Add(this);
      _word = _words[rnd.Next(0, _words.Count - 1)];
      _wrongGuessInstances = new List<char> {};
      _rightGuessInstances = new List<char> {};
    }

    public bool CheckValidGuess(string guess)
    {
      if (_alphabet.Contains(guess[0]))
      {
        return true;
      }
      return false;
    }

    public bool CheckGuess(string guess)
    {
      if (_word.Contains(guess))
      {
        _rightGuessInstances.Add(guess[0]);
        _alphabet.RemoveAt(_alphabet.IndexOf(guess[0]));
        return true;
      }
      else
      {
        _wrongGuessInstances.Add(guess[0]);
        _alphabet.RemoveAt(_alphabet.IndexOf(guess[0]));
        return false;
      }
    }

    public int CheckWrong()
    {
      return _wrongGuessInstances.Count;
    }

    public string GetWord()
    {
      return _word;
    }

    public List<char> GetRightGuesses()
    {
      return _rightGuessInstances;
    }

    public List<char> GetWrongGuesses()
    {
      return _wrongGuessInstances;
    }

    public static Board GetBoard()
    {
      return _instances[0];
    }

  }
}
