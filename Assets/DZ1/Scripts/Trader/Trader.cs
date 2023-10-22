using UnityEngine;

public class Trader : MonoBehaviour
{
    protected ITradeStratagy TradeStratagy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITradeable tradeable))
        {
            Debug.Log("����������� ����!");
            tradeable.RequestTrade += OnTrade;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITradeable tradeable))
        {
            Debug.Log("������");
            tradeable.RequestTrade -= OnTrade;
        }
    }

    private void OnTrade(int request)
    {
        switch (request)
        {
            case 1:
                TradeStratagy = new FructsStratagy(); 
                break;
            case 2: 
                TradeStratagy = new ArmorTradeStratagy();
                break;
            case 3:
                TradeStratagy = new IgnoreTradeStratagy();
                break;
            default:
                Debug.Log("������� 1, 2 ��� ����� ���� 3");
                return;
        }
        TradeStratagy.ShowGoods();
    }
}
