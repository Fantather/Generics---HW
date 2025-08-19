using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Задание 2
// Создайте приложение «Англо-французский словарь»
//
// Необходимо хранить следующую информацию:
// Слово на английском языке;
// Варианты перевода на французский.
// Для хранения информации используйте Dictionary<T>.

// Приложение должно предоставлять такую функциональность:
// Добавление слова и вариантов перевода;
// Удаление слова;
// Удаление варианта перевода;
// Изменение слова;
// Изменение варианта перевода;
// Поиск перевода слова.


namespace Generics_HW.Task_2
{
    internal class EnglishFranchDict
    {
        private readonly Dictionary<string, List<string>> dict = [];
        public IReadOnlyDictionary<string, List<string>> Dict => dict;

        public void AddWord(string originalWord, string translate)
        {
            if(dict.ContainsKey(originalWord) == true)
            {
                AddTranslate(originalWord, translate);
                return;
            }

            dict.Add(originalWord, [translate]);
        }

        public void AddTranslate(string originalWord, string translate)
        {
            if (dict.ContainsKey(originalWord) == false)
            {
                AddWord(originalWord, translate);
                return;
            }

            dict[originalWord].Add(translate);
        }

        public bool RemoveWord(string originalWord) => dict.Remove(originalWord);

        public bool RemoveTranslate(string originalWord, string translate)
        {
            if(dict.ContainsKey(originalWord) == false)
                return false;

            if(dict[originalWord].Remove(translate) == false)
                return false;
            else
                return true;
        }

        public bool ChangeOriginalWord(string originalWord, string newWord)
        {
            if (dict.ContainsKey(originalWord) == false || dict.ContainsKey(newWord) == false)
                return false;

            dict.Add(newWord, dict[originalWord]);
            dict.Remove(originalWord);

            return true;
        }

        public bool ChangeTranslate(string originalWord, string oldTranslate, string newTranslate)
        {
            if (dict.ContainsKey(originalWord) == false)
                return false;

            List<string> translations = dict[originalWord];
            int index = translations.IndexOf(oldTranslate);
            if (index == -1)
                return false;

            translations[index] = newTranslate;
            return true;
        }

        public IReadOnlyList<string>? GetTranslate(string originalWord)
        {
            if (dict.ContainsKey(originalWord) == false)
                return null;

            return dict[originalWord];
        }
    }
}
