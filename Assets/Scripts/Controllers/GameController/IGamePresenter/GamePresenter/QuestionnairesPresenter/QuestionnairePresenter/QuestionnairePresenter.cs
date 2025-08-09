using System.Collections.Generic;
using System.Text;
using System;
using TMPro;
using UnityEngine;

internal abstract class QuestionnairePresenter : MonoBehaviour
{
    internal abstract event Action<QuestionsData> onInputQuestionsModel;
    internal abstract event Action<int> onInputPlayersCountModel;
    internal abstract event Action<StringBuilder> onInputAddSavedStoryModel;
    internal abstract event Action<StringBuilder[]> onInputRemovePlayerModel;
    internal abstract event Action<StringBuilder[]> onInputClearPlayerModel;
    internal abstract event Action onInputAddNewAnswerModels;
    internal abstract event Action<StringBuilder, string> onInputAnswerModel;
    internal abstract event Action<int> onInputQueueModel;

    internal abstract void OutputCreatedStoriesModel(List<StringBuilder> createdStoriesModel);
    internal abstract void OutputFontModel(TMP_FontAsset font);
    internal abstract void OutputQuestionnaireModel(QuestionnaireModel questionnaireModel);
    internal abstract void OutputQueueModel(int queueModel);
    internal abstract void OutputQueuesModel(List<int> queuesModel);
    internal abstract void OutputSavedStoriesModel(List<StringBuilder> savedStoriesMode);
}