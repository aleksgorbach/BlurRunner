﻿using UnityEngine;
using System;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using AOT;

namespace AppodealAds.Unity.iOS
{
	public class AppodealAdsClient : IAppodealAdsClient {
		
		private const int AppodealAdTypeInterstitial  = 1 << 0;
		private const int AppodealAdTypeVideo         = 1 << 1;
		private const int AppodealAdTypeBanner        = 1 << 2;
		private const int AppodealAdTypeRewardedVideo = 1 << 4;
		private const int AppodealAdTypeAll           = AppodealAdTypeInterstitial | AppodealAdTypeVideo | AppodealAdTypeBanner;
		
		private const int AppodealShowStyleInterstitial        = 1;
		private const int AppodealShowStyleVideo               = 2;
		private const int AppodealShowStyleVideoOrInterstitial = 3;
		private const int AppodealShowStyleBannerTop           = 4;
		private const int AppodealShowStyleBannerCenter        = 5;
		private const int AppodealShowStyleBannerBottom        = 6;
		private const int AppodealShowStyleRewardedVideo       = 7;
		
		
		#region Singleton
		
		private AppodealAdsClient(){}
		
		private static readonly AppodealAdsClient instance = new AppodealAdsClient();
		
		public static AppodealAdsClient Instance {
			get {
				return instance; 
			}
		}
		
		#endregion
		
		private static IInterstitialAdListener interstitialListener;
		private static IVideoAdListener videoListener;
		private static IRewardedVideoAdListener rewardedVideoListener;
		private static IBannerAdListener bannerListener;
		
		#region Interstitial Delegate
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void interstitialDidLoad () {
			if (AppodealAdsClient.interstitialListener != null) {
				AppodealAdsClient.interstitialListener.onInterstitialLoaded();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void interstitialDidFailToLoad () {
			if (AppodealAdsClient.interstitialListener != null) {
				AppodealAdsClient.interstitialListener.onInterstitialFailedToLoad();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void interstitialDidClick () {
			if (AppodealAdsClient.interstitialListener != null) {
				AppodealAdsClient.interstitialListener.onInterstitialClicked();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void interstitialDidDismiss () {
			if (AppodealAdsClient.interstitialListener != null) {
				AppodealAdsClient.interstitialListener.onInterstitialClosed();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void interstitialWillPresent () {
			if (AppodealAdsClient.interstitialListener != null) {
				AppodealAdsClient.interstitialListener.onInterstitialShown();
			}
		}
		
		public void setInterstitialCallbacks(IInterstitialAdListener listener) {
			AppodealAdsClient.interstitialListener = listener;
			
			AppodealObjCBridge.AppodealSetInterstitialDelegate(AppodealAdsClient.interstitialDidLoad,
			                                                   AppodealAdsClient.interstitialDidFailToLoad,
			                                                   AppodealAdsClient.interstitialDidClick,
			                                                   AppodealAdsClient.interstitialDidDismiss,
			                                                   AppodealAdsClient.interstitialWillPresent);
		}
		
		#endregion
		
		#region Video Delegate
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void videoDidLoadAd() {
			if (AppodealAdsClient.videoListener != null) {
				AppodealAdsClient.videoListener.onVideoLoaded();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void videoDidFailToLoadAd() {
			if (AppodealAdsClient.videoListener != null) {
				AppodealAdsClient.videoListener.onVideoFailedToLoad();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void videoWillDismiss() {
			if (AppodealAdsClient.videoListener != null) {
				AppodealAdsClient.videoListener.onVideoClosed();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void videoDidFinish() {
			if (AppodealAdsClient.videoListener != null) {
				AppodealAdsClient.videoListener.onVideoFinished();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void videoDidPresent() {
			if (AppodealAdsClient.videoListener != null) {
				AppodealAdsClient.videoListener.onVideoShown();
			}
		}
		
		public void setVideoCallbacks(IVideoAdListener listener) {
			AppodealAdsClient.videoListener = listener;
			
			AppodealObjCBridge.AppodealSetVideoDelegate(AppodealAdsClient.videoDidLoadAd,
			                                            AppodealAdsClient.videoDidFailToLoadAd,
			                                            AppodealAdsClient.videoWillDismiss,
			                                            AppodealAdsClient.videoDidFinish,
			                                            AppodealAdsClient.videoDidPresent);
			
		}
		
		#endregion
		
		#region Rewarded Video Delegate
		
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void rewardedVideoDidLoadAd() {
			if (AppodealAdsClient.rewardedVideoListener != null) {
				AppodealAdsClient.rewardedVideoListener.onRewardedVideoLoaded();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void rewardedVideoDidFailToLoadAd() {
			if (AppodealAdsClient.rewardedVideoListener != null) {
				AppodealAdsClient.rewardedVideoListener.onRewardedVideoFailedToLoad();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void rewardedVideoWillDismiss() {
			if (AppodealAdsClient.rewardedVideoListener != null) {
				AppodealAdsClient.rewardedVideoListener.onRewardedVideoClosed();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealRewardedVideoDidFinishDelegate))]
		private static void rewardedVideoDidFinish(int amount, String name) {
			if (AppodealAdsClient.rewardedVideoListener != null) {
				AppodealAdsClient.rewardedVideoListener.onRewardedVideoFinished(amount, name);
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void rewardedVideoDidPresent() {
			if (AppodealAdsClient.rewardedVideoListener != null) {
				AppodealAdsClient.rewardedVideoListener.onRewardedVideoShown();
			}
		}
		
		public void setRewardedVideoCallbacks(IRewardedVideoAdListener listener) {
			AppodealAdsClient.rewardedVideoListener = listener;
			
			AppodealObjCBridge.AppodealSetRewardedVideoDelegate(AppodealAdsClient.rewardedVideoDidLoadAd,
			                                                    AppodealAdsClient.rewardedVideoDidFailToLoadAd,
			                                                    AppodealAdsClient.rewardedVideoWillDismiss,
			                                                    AppodealAdsClient.rewardedVideoDidFinish,
			                                                    AppodealAdsClient.rewardedVideoDidPresent);
			
		}
		
		#endregion
		
		
		#region Banner Delegate
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void bannerDidLoadAd() {
			if (AppodealAdsClient.bannerListener != null) {
				AppodealAdsClient.bannerListener.onBannerLoaded();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void bannerDidFailToLoadAd() {
			if (AppodealAdsClient.bannerListener != null) {
				AppodealAdsClient.bannerListener.onBannerFailedToLoad();
			}
		}
		
		[MonoPInvokeCallback (typeof (AppodealNativeDelegate))]
		private static void bannerDidClick () {
			if (AppodealAdsClient.bannerListener != null) {
				AppodealAdsClient.bannerListener.onBannerClicked();
			}
		}
		
		public void setBannerCallbacks(IBannerAdListener listener) {
			AppodealAdsClient.bannerListener = listener;
			
			AppodealObjCBridge.AppodealSetBannerDelegate(AppodealAdsClient.bannerDidLoadAd,
			                                             AppodealAdsClient.bannerDidFailToLoadAd,
			                                             AppodealAdsClient.bannerDidClick);
			
		}
		
		#endregion
		
		private int nativeAdTypesForType(int adTypes) {
			int nativeAdTypes = 0;
			
			if ((adTypes & Appodeal.INTERSTITIAL) > 0) {
				nativeAdTypes |= AppodealAdTypeInterstitial;
			}
			
			if ((adTypes & Appodeal.VIDEO) > 0) {
				nativeAdTypes |= AppodealAdTypeVideo;
			}
			
			if ((adTypes & Appodeal.BANNER) > 0 || 
			    (adTypes & Appodeal.BANNER_TOP) > 0 || 
			    (adTypes & Appodeal.BANNER_CENTER) > 0 || 
			    (adTypes & Appodeal.BANNER_BOTTOM) > 0) {
				
				nativeAdTypes |= AppodealAdTypeBanner;
			}
			
			if ((adTypes & Appodeal.REWARDED_VIDEO) > 0) {
				nativeAdTypes |= AppodealAdTypeRewardedVideo;
			}
			
			return nativeAdTypes;
		}
		
		private int nativeShowStyleForType(int adTypes) {
			bool isInterstitial = (adTypes & Appodeal.INTERSTITIAL) > 0;
			bool isVideo = (adTypes & Appodeal.VIDEO) > 0;
			
			if (isInterstitial && isVideo) {
				return AppodealShowStyleVideoOrInterstitial;
			} else if (isVideo) {
				return AppodealShowStyleVideo;
			} else if (isInterstitial) {
				return AppodealShowStyleInterstitial;
			}
			
			if ((adTypes & Appodeal.BANNER_TOP) > 0) {
				return AppodealShowStyleBannerTop;
			}
			
			if ((adTypes & Appodeal.BANNER_CENTER) > 0) {
				return AppodealShowStyleBannerCenter;
			}
			
			if ((adTypes & Appodeal.BANNER_BOTTOM) > 0) {
				return AppodealShowStyleBannerBottom;
			}
			
			if ((adTypes & Appodeal.REWARDED_VIDEO) > 0) {
				return AppodealShowStyleRewardedVideo;
			}
			
			return 0;
		}
		
		public void initialize(string appKey, int adTypes) {
			AppodealObjCBridge.AppodealInitializeWithTypes(appKey, nativeAdTypesForType(adTypes));
		}
		
		public void cache(int adTypes) {
			AppodealObjCBridge.AppodealCacheAd(nativeAdTypesForType(adTypes));
		}
		
		public Boolean isLoaded(int adTypes) {
			int style = nativeShowStyleForType(adTypes);
			bool isBanner = style == AppodealShowStyleBannerTop || style == AppodealShowStyleBannerCenter || style == AppodealShowStyleBannerBottom;
			
			return isBanner ? true : AppodealObjCBridge.AppodealIsReadyWithStyle(style);
		}
		
		public Boolean isPrecache(int adTypes) {
			// TODO: not implented in iOS SDK yet
			return false;
		}
		
		public Boolean show(int adTypes) {
			return AppodealObjCBridge.AppodealShowAd(nativeShowStyleForType(adTypes));
		}
		
		public Boolean showWithPriceFloor(int adTypes) {
			// TODO: not implented in iOS SDK yet
			return show(adTypes); // fallback to normal show
		}
		
		public void hide(int adTypes) {
			if ((nativeAdTypesForType(adTypes) & AppodealAdTypeBanner) > 0) {
				AppodealObjCBridge.AppodealHideBanner();
			}
		}
		
		public void setAutoCache(int adTypes, Boolean autoCache) {
			AppodealObjCBridge.AppodealSetAutocache(autoCache, nativeAdTypesForType(adTypes));
		}
		
		public void setTesting(Boolean test) {
			AppodealObjCBridge.AppodealSetDebugEnabled(test);
		}
		
		public void setLogging(Boolean logging) {
			// TODO: not implented in iOS SDK yet
		}
		
		public void setOnLoadedTriggerBoth(int adTypes, Boolean onLoadedTriggerBoth) {
			// TODO: not implented in iOS SDK yet
		}
		
		public void disableNetwork(String network) {
			AppodealObjCBridge.AppodealDisableNetwork(network);
		}
		
		public void disableNetwork(String network, int adTypes) {
			AppodealObjCBridge.AppodealDisableNetworkForAdTypes(network, nativeAdTypesForType(adTypes));
		}
		
		public void disableLocationPermissionCheck() 
		{
			AppodealObjCBridge.AppodealDisableLocationPermissionCheck();
		}
		
		public void orientationChange() {} // handled by SDK
		
		
		public string getVersion() {
			return AppodealObjCBridge.AppodealGetVersion();
		}
		
		public Boolean isLoadedWithPriceFloor(int adTypes)
		{
			// TODO: not implented in iOS SDK yet
			return false;
		}
		
		//User Settings
		
		public void getUserSettings() {
			// No additional state change required on iOS
		}
		
		public void setAge(int age) 
		{
			AppodealObjCBridge.AppodealSetUserAge(age);
		}
		
		public void setBirthday(string bDay)
		{
			AppodealObjCBridge.AppodealSetUserBirthday(bDay);
		}
		
		public void setEmail(String email)
		{
			AppodealObjCBridge.AppodealSetUserEmail(email);
		}
		
		public void setFacebookId(String fbId)
		{
			AppodealObjCBridge.AppodealSetUserFacebookId(fbId);
		}
		
		public void setVkId(String vkId)
		{
			AppodealObjCBridge.AppodealSetUserVkId(vkId);
		}
		
		public void setGender(int gender)
		{
			AppodealObjCBridge.AppodealSetUserGender(gender - 1); // iOS Enum starts from 0
		}
		
		public void setInterests(String interests)
		{
			AppodealObjCBridge.AppodealSetUserInterests(interests);
		}
		
		public void setOccupation(int occupation)
		{
			AppodealObjCBridge.AppodealSetUserOccupation(occupation - 1);
		}
		
		public void setRelation(int relation)
		{
			AppodealObjCBridge.AppodealSetUserRelationship(relation - 1);
		}
		
		public void setAlcohol(int alcohol)
		{
			AppodealObjCBridge.AppodealSetUserAlcoholAttitude(alcohol);
		}
		
		public void setSmoking(int smoking)
		{
			AppodealObjCBridge.AppodealSetUserSmokingAttitude(smoking);
		}
		
	}
}