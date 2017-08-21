using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JT_TrieData {
	List<string> word_opt;	// all possible words that can be formed at this level
	List<string> suffix;	// most popular words from child nodes
}

public class JT_TrieTable{
	Dictionary<string, JT_TrieData> CardinalMonoTrie;
	Dictionary<string, JT_TrieData> CardinalDuoTrie;
	Dictionary<string, JT_TrieData> AplhaMonoTrie;
	Dictionary<string, JT_TrieData> AplhaDuoTrie;
	Dictionary<string, JT_TrieData> DuMonoTrie;
	
}
