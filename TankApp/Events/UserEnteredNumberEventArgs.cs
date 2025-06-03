// ����������� ������������ ������������ ��� System, 
// ������� �������� ������� ������ � ������ ��� ������ � .NET
using System;

// ����������� ������������ ��� TankApp.Events, 
// ����� ��������� ������������� ��������� ���� (� ������ ������ � �������)
namespace TankApp.Events
{
    // ����� UserEnteredNumberEventArgs ������������ ����� ���������������� �������� �������.
    // ������������ ��� ������������� �������, ����� ������������ ������ �����.
    public class UserEnteredNumberEventArgs : EventArgs
    {
        // �������� Input ������ �������� �����, ��������� �������������
        public int Input { get; set; }

        // �������� EnteredAt ��������� �����, ����� ���� ������� �����
        public DateTime EnteredAt { get; set; }
    }
}