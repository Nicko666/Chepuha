using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class StoriesController : IStoriesController
{
    private List<StringBuilder> _savedStories;

    public event Action<List<StringBuilder>> onCreatedStorieModelsChanged;
    public event Action<List<StringBuilder>> onSavedStorieModelsChanged;

    public void SetDataModel(DataModel dataModel) =>
        onSavedStorieModelsChanged.Invoke(_savedStories = dataModel.stories.ConvertAll(i => new StringBuilder(i)));

    public void GetDataModel(ref DataModel dataModel) =>
        dataModel.stories =_savedStories.ConvertAll(i => i.ToString());
    
    public void SetQuestionnaireModels(QuestionnaireModel questionnairesModel)
    {
        List<StringBuilder[]> addedAnswers = new(questionnairesModel.playersModel);

        while (addedAnswers.Count < 2)
        {
            StringBuilder[] randomAnswers = new StringBuilder[questionnairesModel.questionsModel.Length];

            for (int i = 0; i < randomAnswers.Length; i++)
                randomAnswers[i] = new(questionnairesModel.questionsModel[i]
                    .randomAnswers[UnityEngine.Random.Range(0, questionnairesModel.questionsModel[i].randomAnswers.Length)]);

            addedAnswers.Add(randomAnswers);
        }

        List<StringBuilder> _createdStories = new();
        
        int playersCount = addedAnswers.Count;
        int answersCount = questionnairesModel.questionsModel.Length;

        for (int i = 0; i < playersCount; i++)
        {
            _createdStories.Add(new StringBuilder());
            int tempPlayerNumber = i;
            for (int j = 0; j < answersCount; j++)
            {
                StringBuilder answer = addedAnswers[tempPlayerNumber % playersCount][j];

                if (answer.Length > 0 && questionnairesModel.questionsModel[j].isUppercase)
                    answer = new StringBuilder().Append(char.ToUpper(answer[0])).Append(answer, 1, answer.Length - 1);

                _createdStories[i].Append(answer);
                _createdStories[i].Append(questionnairesModel.questionsModel[j].textAfter);

                tempPlayerNumber++;
            }
        }
        
        onCreatedStorieModelsChanged.Invoke(_createdStories);
    }

    public void AddSavedStoryModel(StringBuilder storyModel)
    {
        _savedStories.Add(storyModel);

        onSavedStorieModelsChanged.Invoke(_savedStories);
    }

    public void RemoveSavedStoryModel(StringBuilder savedStoryModel)
    {
        _savedStories.Remove(savedStoryModel);

        onSavedStorieModelsChanged.Invoke(_savedStories);
    }

    public void Dispose() { }
}