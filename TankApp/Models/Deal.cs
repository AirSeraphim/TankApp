// ����������� ������������ ��� TankApp.Models.
// ����� ��������� ������, �������������� ������ ���������� ������� ����������.
namespace TankApp.Models
{
    /// <summary>
    /// ����� Deal ������������ ������ � �������.
    /// �������� �������� ��������, ��������������� ������.
    /// </summary>
    public class Deal
    {
        /// <summary>
        /// ����� ������.
        /// </summary>
        public int Sum { get; set; }

        /// <summary>
        /// ���������� ������������� ������.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// ���� ���������� ������.
        /// </summary>
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// ������ (record) SumByMonth ������������ �������������� ���������� � ����� ������ �� ����������� �����.
    /// Records ������ ��� ������������ ������� � ������������� ������������ ��������� ��������� �� ��������.
    /// </summary>
    /// <param name="Month">�����, �� ������� ���������� �����</param>
    /// <param name="Sum">����� ����� ������ �� ��������� �����</param>
    public record SumByMonth(DateTime Month, int Sum);
}