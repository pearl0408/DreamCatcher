using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum category { Development, Wallpaper, SpecialProduct};    //카테고리 열거형

public class CategorySelect : MonoBehaviour
{
    //카테고리 선택 부분을 담당하는 클래스

    [Header("Store Select")]
    [SerializeField] private int currentCategory; //현재 선택된 상점 화면(보이는 화면)
    [SerializeField] private GameObject[] CategoryProducts;   //해당 카테고리 상품 화면

    [Space]
    [Header("Category Background")]
    [SerializeField] private GameObject[] UnselectedBackGround;   //비활성화된 카테고리 배경

    void Start()
    {
        currentCategory = (int)category.Development;   //기본은 보조도구 화면
        CategoryProducts[currentCategory].SetActive(true);     //해당 카테고리 상품 화면 활성화
    }

    public int GetSelectedCategory()
    {
        //선택된 화면을 반환하는 함수

        return currentCategory;
    }

    public void SetDevelopmentSelect()
    {
        //보조도구 화면을 선택하는 함수

        SetInActiveBeforeCategory(currentCategory);     //이전 카테고리 비활성화
        currentCategory = (int)category.Development;
        SetActiveCurrentCategory(currentCategory);      //현재 카테고리 활성화
    }

    public void SetWallpaperSelect()
    {
        //벽지 화면을 선택하는 함수

        SetInActiveBeforeCategory(currentCategory);     //이전 카테고리 비활성화
        currentCategory = (int)category.Wallpaper;
        SetActiveCurrentCategory(currentCategory);      //현재 카테고리 활성화
    }

    public void SetSpecialProductSelect()
    {
        //특별상품 화면을 선택하는 함수

        SetInActiveBeforeCategory(currentCategory);
        currentCategory = (int)category.SpecialProduct;
        SetActiveCurrentCategory(currentCategory);      //현재 카테고리 활성화
    }

    private void SetActiveCurrentCategory(int currentCategory)
    {
        //현재 카테고리를 활성화 하는 함수

        CategoryProducts[currentCategory].SetActive(true);     //현재 카테고리 상품 화면 활성화
        UnselectedBackGround[currentCategory].SetActive(false); // 현재 카테고리 비활성화 배경 비활성화
    }

    private void SetInActiveBeforeCategory(int beforeCategory)
    {
        //이전 카테고리를 비활성화 하는 함수

        CategoryProducts[beforeCategory].SetActive(false);     //이전 카테고리 상품 화면 비활성화
        UnselectedBackGround[beforeCategory].SetActive(true); // 이전 카테고리 비활성화 배경 활성화
    }
}
