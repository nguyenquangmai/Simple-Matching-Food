using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaypalPayment : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtPaypalPayment;
    public Button payButton;
    public int testIndex = 0;
    public string backendCreateOrderURL = "";

    void Start()
    {
        payButton.onClick.AddListener(OnClickPayButton);
    }

    void OnClickPayButton()
    {
        StartCoroutine(TestFlow());
    }

    IEnumerator TestFlow()
    {
        txtPaypalPayment.text = $"[STEP 1] Start order creation for index: {testIndex}";

        yield return new WaitForSeconds(1f);

        txtPaypalPayment.text = "[STEP 2] Simulating backend request...";

        yield return new WaitForSeconds(1f);

        string fakeJson = "";

        txtPaypalPayment.text = "[STEP 3] Backend response received: " + fakeJson;

        string approvalUrl = ExtractApprovalUrl(fakeJson);
        
        txtPaypalPayment.text = "[STEP 4] Approval URL extracted: " + approvalUrl;

        if (!string.IsNullOrEmpty(approvalUrl))
        {
            yield return new WaitForSeconds(1f);
            txtPaypalPayment.text = "[STEP 5] Opening PayPal URL (simulated)";
        }

        yield return new WaitForSeconds(1f);

        txtPaypalPayment.text =  $"[STEP 6] Order completed for index: {testIndex}";

        yield return new WaitForSeconds(1f);

        RewardUser();
    }

    private void RewardUser()
    {
        testIndex++;

        txtPaypalPayment.text = $"[DEBUG] testIndex now = {testIndex}";
    }

    string ExtractApprovalUrl(string json)
    {
        int start = json.IndexOf("");
        if (start < 0) return null;
        int end = json.IndexOf("", start);
        return json.Substring(start, end - start);
    }
}
