// ����������� ����������������� ������������ ��� TankApp.Interfaces,
// ����� ����� ������ � ���������� IEntity, ������� ����������� � ���� ������
using TankApp.Interfaces;

// ����������� ������������ ��� TankApp.Models � ����� ��������� ������ ���������� ������� ����������
namespace TankApp.Models
{
    /// <summary>
    /// ����� Factory ������������ ����� (���������������� �����������) � �������.
    /// ��������� ��������� IEntity, ����������� ������� �������� ��� ���� ���������.
    /// </summary>
    public class Factory : IEntity
    {
        /// <summary>
        /// ���������� ������������� ������ (GUID).
        /// ������������ ������������� ��� �������� �������.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// �������� ������. ����� ���������� � ����������.
        /// </summary>
        public string Name { get; set; }
    }
}