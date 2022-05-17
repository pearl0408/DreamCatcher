using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum category { Development, Wallpaper, SpecialProduct};    //ī�װ� ������

public class CategorySelect : MonoBehaviour
{
    //ī�װ� ���� �κ��� ����ϴ� Ŭ����

    [Header("Store Select")]
    [SerializeField] private int currentCategory; //���� ���õ� ���� ȭ��(���̴� ȭ��)
    [SerializeField] private GameObject[] CategoryProducts;   //�ش� ī�װ� ��ǰ ȭ��

    [Space]
    [Header("Category Background")]
    [SerializeField] private GameObject[] UnselectedBackGround;   //��Ȱ��ȭ�� ī�װ� ���

    void Start()
    {
        currentCategory = (int)category.Development;   //�⺻�� �������� ȭ��
        CategoryProducts[currentCategory].SetActive(true);     //�ش� ī�װ� ��ǰ ȭ�� Ȱ��ȭ
    }

    public int GetSelectedCategory()
    {
        //���õ� ȭ���� ��ȯ�ϴ� �Լ�

        return currentCategory;
    }

    public void SetDevelopmentSelect()
    {
        //�������� ȭ���� �����ϴ� �Լ�

        SetInActiveBeforeCategory(currentCategory);     //���� ī�װ� ��Ȱ��ȭ
        currentCategory = (int)category.Development;
        SetActiveCurrentCategory(currentCategory);      //���� ī�װ� Ȱ��ȭ
    }

    public void SetWallpaperSelect()
    {
        //���� ȭ���� �����ϴ� �Լ�

        SetInActiveBeforeCategory(currentCategory);     //���� ī�װ� ��Ȱ��ȭ
        currentCategory = (int)category.Wallpaper;
        SetActiveCurrentCategory(currentCategory);      //���� ī�װ� Ȱ��ȭ
    }

    public void SetSpecialProductSelect()
    {
        //Ư����ǰ ȭ���� �����ϴ� �Լ�

        SetInActiveBeforeCategory(currentCategory);
        currentCategory = (int)category.SpecialProduct;
        SetActiveCurrentCategory(currentCategory);      //���� ī�װ� Ȱ��ȭ
    }

    private void SetActiveCurrentCategory(int currentCategory)
    {
        //���� ī�װ��� Ȱ��ȭ �ϴ� �Լ�

        CategoryProducts[currentCategory].SetActive(true);     //���� ī�װ� ��ǰ ȭ�� Ȱ��ȭ
        UnselectedBackGround[currentCategory].SetActive(false); // ���� ī�װ� ��Ȱ��ȭ ��� ��Ȱ��ȭ
    }

    private void SetInActiveBeforeCategory(int beforeCategory)
    {
        //���� ī�װ��� ��Ȱ��ȭ �ϴ� �Լ�

        CategoryProducts[beforeCategory].SetActive(false);     //���� ī�װ� ��ǰ ȭ�� ��Ȱ��ȭ
        UnselectedBackGround[beforeCategory].SetActive(true); // ���� ī�װ� ��Ȱ��ȭ ��� Ȱ��ȭ
    }
}
