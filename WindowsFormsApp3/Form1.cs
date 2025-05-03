using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\WindowsFormsApp3\WindowsFormsApp3\Database1.mdf;Integrated Security=True";
        private List<string> bookedseats = new List<string>();
        public Form1()
        {
            InitializeComponent();
            InitializeData();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeData()
        {
            cmbMovies.Items.AddRange(new string[] { "HarryPotter", "Iron Man", "Hulk", "ThunderBolts" });
            cmbShowtimes.Items.AddRange(new string[] { "10:00 AM", "1:00 PM", "4:00 PM", "7:00 PM" });
            cmbSeats.Items.AddRange(new string[] { "Ax1", "Ax2", "Ax3", "Bx1", "Bx2", "Bx3" });
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            string seat = cmbSeats.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(seat) || bookedseats.Contains(seat))
            {
                MessageBox.Show("Seat already booked or not selected!", "Error");
                return;
            }

            TicketBooking booking = new TicketBooking(
                cmbMovies.SelectedItem?.ToString(),
                cmbShowtimes.SelectedItem?.ToString(),
                seat,
                txtCustomerName.Text,
                txtContact.Text
            );

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Bookings (Movie, Showtime, Seat, CustomerName, Contact) VALUES (@Movie, @Showtime, @Seat, @CustomerName, @Contact)";



                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Movie", booking.Movie);
                cmd.Parameters.AddWithValue("@Showtime", booking.Showtime);
                cmd.Parameters.AddWithValue("@Seat", booking.Seat);
                cmd.Parameters.AddWithValue("@CustomerName", booking.CustomerName);
                cmd.Parameters.AddWithValue("@Contact", booking.Contact);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            bookedseats.Add(seat);
            MessageBox.Show(booking.GetBookingDetails(), "Booking Confirmed");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
