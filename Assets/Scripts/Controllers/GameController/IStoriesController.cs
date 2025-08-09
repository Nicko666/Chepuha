using System;
using System.Collections.Generic;
using System.Text;

public interface IStoriesController : IDisposable
{
    event Action<List<StringBuilder>> onSavedStorieModelsChanged;
    event Action<List<StringBuilder>> onCreatedStorieModelsChanged;

    void SetDataModel(DataModel dataModel);
    void GetDataModel(ref DataModel dataModel);
    void SetQuestionnaireModels(QuestionnaireModel questionnairesModel);
    void AddSavedStoryModel(StringBuilder storyModel);
    void RemoveSavedStoryModel(StringBuilder savedStoryModel);
}