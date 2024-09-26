using Microsoft.AspNetCore.Components.Forms;

using YSPT.Configurations.Common;

namespace TOS.Components.Helper;

public static class FormHelper
{
    public static void ShowFormValidationError<T>(this ApiResponse<T> apiResponse, ValidationMessageStore? messageStore, EditContext? editContext)
    {
        if (messageStore is null || editContext is null)
        {
            return;
        }
        if (!apiResponse.IsFormValidationError)
        {
            return;
        }

        messageStore.Clear();
        editContext.NotifyValidationStateChanged();

        foreach (var error in apiResponse.Errors)
        {
            messageStore.Add(editContext.Field(error.Key), error.Value);
        }

        editContext.NotifyValidationStateChanged();
    }

    public static void ShowFormValidationError<T>(this EditContext editContext, ValidationMessageStore messageStore, ApiResponse<T> apiResponse)
    {
        apiResponse.ShowFormValidationError(messageStore, editContext);
    }
}