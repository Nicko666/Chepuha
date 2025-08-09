using System.Collections.Generic;
using System.Text;
using System;
using TMPro;
using UnityEngine;

internal abstract class SavedStoriesPresenter : MonoBehaviour
{
    internal abstract event Action<StringBuilder> onInputSavedStoryModelRemove;
    internal abstract void OutputSavedStories(List<StringBuilder> storyModels);
    internal abstract void OutputFont(TMP_FontAsset font);
}
