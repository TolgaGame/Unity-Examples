using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class Purchaser : MonoBehaviour, IStoreListener
{
	private static IStoreController m_StoreController;
	private static IExtensionProvider m_StoreExtensionProvider;

    public static string coin1 = Constants.PACK_1;
    public static string coin2 = Constants.PACK_2;
    public static string coin3 = Constants.PACK_3;
    public static string coin4 = Constants.PACK_4;
    public static string coin5 = Constants.PACK_5;


    //Arayüzde coinlerin yazılı olduğu yer
    public Text Coinstext;

	void Start(){
		if (m_StoreController == null){
			InitializePurchasing();
		}
	}

	public void InitializePurchasing() {
		if (IsInitialized()){
			return;
		}

		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
		builder.AddProduct(coin1, ProductType.Consumable);
		builder.AddProduct(coin2, ProductType.Consumable);
		builder.AddProduct(coin3, ProductType.Consumable);
		builder.AddProduct(coin4, ProductType.Consumable);
        builder.AddProduct(coin5, ProductType.Consumable);


        UnityPurchasing.Initialize(this, builder);
	}


	private bool IsInitialized(){
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}


    public void BuyHint(int id)
    {
        if (id == 0)
        {
            BuyProductID(coin1);
        }
        else if (id == 1)
        {
            BuyProductID(coin2);
        }
        else if (id == 2)
        {
            BuyProductID(coin3);
        }
        else if (id == 3)
        {
            BuyProductID(coin4);

        }
        else if (id == 4)
        {
            BuyProductID(coin5);
        }
    }
	

	void BuyProductID(string productId){
		if (IsInitialized()){
			Product product = m_StoreController.products.WithID(productId);

			if (product != null && product.availableToPurchase){
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
				m_StoreController.InitiatePurchase(product);
			} else {
				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
			}
		} else {
			Debug.Log("BuyProductID FAIL. Not initialized.");
		}
	}

	public void RestorePurchases(){
		if (!IsInitialized()){
			Debug.Log("RestorePurchases FAIL. Not initialized.");
			return;
		}

		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer){
			Debug.Log("RestorePurchases started ...");

			var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			apple.RestoreTransactions((result) => {
				Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			});
		} else {
			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
		}
	}

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions){
		Debug.Log("OnInitialized: PASS");

		m_StoreController = controller;
		m_StoreExtensionProvider = extensions;
	}

	public void OnInitializeFailed(InitializationFailureReason error){
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	}

    
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) {

        if (String.Equals(args.purchasedProduct.definition.id, coin1, StringComparison.Ordinal)){
            int prevGem = PlayerPrefs.GetInt("gem");
            PlayerPrefs.SetInt("gem", prevGem + 50);
            Coinstext.text = PlayerPrefs.GetInt("gem").ToString();

        } else if (String.Equals(args.purchasedProduct.definition.id, coin2, StringComparison.Ordinal)){
            int prevGem = PlayerPrefs.GetInt("gem");
            PlayerPrefs.SetInt("gem", prevGem + 100);
            Coinstext.text = PlayerPrefs.GetInt("gem").ToString();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coin3, StringComparison.Ordinal)){
            int prevGem = PlayerPrefs.GetInt("gem");
            PlayerPrefs.SetInt("gem", prevGem + 200);
            Coinstext.text = PlayerPrefs.GetInt("gem").ToString();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coin4, StringComparison.Ordinal)){
            int prevGem = PlayerPrefs.GetInt("gem");
            PlayerPrefs.SetInt("gem", prevGem + 250);
            Coinstext.text = PlayerPrefs.GetInt("gem").ToString();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coin5, StringComparison.Ordinal))
        {
            int prevGem = PlayerPrefs.GetInt("gem");
            PlayerPrefs.SetInt("gem", prevGem + 300);
            Coinstext.text = PlayerPrefs.GetInt("gem").ToString();
        }
        else {
			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
		}

		return PurchaseProcessingResult.Complete;
	}

	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason){
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
	}
}