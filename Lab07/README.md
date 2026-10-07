# Lab 07 - SDI, MDI và Ứng dụng nhiều Form trong C# WinForms (ShopManagerMini)

## Thông tin sinh viên
- **Họ và tên**: Hoàng Dương Phúc Quang
- **MSSV**: 49.01.101.075
- **Lớp**: 49.01.TOAN.SN
- **Nhóm**: 11
- **Học phần**: COMP1019 - Lập trình trên Windows
- **Giảng viên hướng dẫn**: ThS. Lê Thanh Thoại
- **Buổi thực hành**: Buổi 7 (Lab 07) - SDI, MDI và ứng dụng nhiều Form trong C# WinForms

---

## 1. Mục tiêu bài thực hành
- Xây dựng ứng dụng Windows Forms đa cửa sổ theo kiến trúc **MDI (Multiple Document Interface)** mang tên `ShopManagerMini`.
- Hiện thực màn hình đăng nhập modal (`FrmLogin`) sử dụng `ShowDialog()` và truyền thông tin phiên đăng nhập của người dùng sang màn hình chính (`FrmMain`).
- Thiết lập màn hình chính `FrmMain` làm `MdiContainer` hoàn chỉnh, trang bị hệ thống `MenuStrip`, `ToolStrip` và `StatusStrip`.
- Cài đặt thuật toán mở Form con MDI an toàn, **ngăn chặn mở trùng lặp Form cùng loại** (`child.Activate()`).
- Xây dựng hoàn chỉnh màn hình Quản lý sản phẩm (`FrmProduct`) với đầy đủ các thao tác CRUD và kiểm tra nghiệp vụ trong bộ nhớ.
- Xây dựng màn hình Quản lý khách hàng (`FrmCustomer`) với đầy đủ chức năng Thêm, Sửa, Xóa, Tìm kiếm bằng `DataGridView`.
- Thiết kế màn hình Giới thiệu (`FrmAbout`) hiển thị đầy đủ thông tin sinh viên, lớp và học phần.
- Quản lý dữ liệu tập trung trong bộ nhớ thông qua `DataStore` dùng chung, đảm bảo tính nhất quán dữ liệu giữa các Form.

---

## 2. Cấu trúc thư mục mã nguồn
```text
Lab07/
├── README.md                                    # Báo cáo chi tiết và trả lời câu hỏi lý thuyết Lab 07
├── ShopManagerMini.sln                          # Solution Visual Studio chuẩn
├── ShopManagerMini.slnx                         # Solution định dạng mới (VS 2022+)
└── ShopManagerMini/
    ├── ShopManagerMini.csproj                   # File cấu hình dự án C# WinForms (.NET Framework 4.7.2)
    ├── App.config                               # Cấu hình runtime ứng dụng
    ├── Program.cs                               # Điểm khởi chạy ứng dụng (Main Entry Point)
    ├── Models/
    │   ├── User.cs                              # Thực thể người dùng đăng nhập
    │   ├── Product.cs                           # Thực thể sản phẩm
    │   └── Customer.cs                          # Thực thể khách hàng
    ├── Services/
    │   └── DataStore.cs                         # Kho dữ liệu tập trung trong bộ nhớ (In-memory Store)
    ├── Forms/
    │   ├── FrmLogin.cs                          # Giao diện & xử lý đăng nhập (Modal Dialog)
    │   ├── FrmLogin.Designer.cs
    │   ├── FrmLogin.resx
    │   ├── FrmMain.cs                           # Form chính MDI Parent Container
    │   ├── FrmMain.Designer.cs
    │   ├── FrmMain.resx
    │   ├── FrmProduct.cs                        # Form con Quản lý sản phẩm (MDI Child)
    │   ├── FrmProduct.Designer.cs
    │   ├── FrmProduct.resx
    │   ├── FrmCustomer.cs                       # Form con Quản lý khách hàng (MDI Child)
    │   ├── FrmCustomer.Designer.cs
    │   ├── FrmCustomer.resx
    │   ├── FrmAbout.cs                          # Form Giới thiệu thông tin phần mềm (Dialog)
    │   ├── FrmAbout.Designer.cs
    │   └── FrmAbout.resx
    └── Properties/
        ├── AssemblyInfo.cs                      # Thông tin định danh Assembly
        ├── Resources.Designer.cs
        ├── Resources.resx
        ├── Settings.Designer.cs
        └── Settings.settings
```

---

## 3. Danh sách Form và Tài khoản mẫu

### 3.1. Danh sách Form thực hiện

| Tên Form | Vai trò | Mô tả chức năng chính |
| :--- | :--- | :--- |
| `FrmLogin` | Đăng nhập | Nhập username/password, kiểm tra bỏ trống, đối chiếu tài khoản mẫu, trả `DialogResult.OK` khi hợp lệ. |
| `FrmMain` | Màn hình chính | `IsMdiContainer = true`, chứa `MenuStrip`, `ToolStrip`, `StatusStrip` (tên người dùng, vai trò, đồng hồ thực), điều phối các form con. |
| `FrmProduct` | Quản lý sản phẩm | MDI Child: CRUD sản phẩm trong bộ nhớ, hiển thị `DataGridView`, kiểm tra mã trùng, kiểm tra giá/số lượng không âm. |
| `FrmCustomer` | Quản lý khách hàng | MDI Child: CRUD khách hàng trong bộ nhớ, hiển thị `DataGridView`, kiểm tra mã trùng, kiểm tra định dạng số điện thoại. |
| `FrmAbout` | Giới thiệu | Dialog hiển thị thông tin đồ án: Hoàng Dương Phúc Quang - MSSV: 49.01.101.075 - Lớp: 49.01.TOAN.SN. |

### 3.2. Bảng tài khoản đăng nhập mẫu

| Tên đăng nhập | Mật khẩu | Họ và tên | Vai trò | Quyền hạn |
| :--- | :--- | :--- | :--- | :--- |
| `admin` | `123` | Quản trị viên | Admin | Quản trị toàn quyền hệ thống |
| `user` | `123` | Nhân viên bán hàng | User | Thao tác quản lý nghiệp vụ thường |

---

## 4. Hiện thực kỹ thuật cốt lõi

### 4.1. Điều phối phiên làm việc tại `Program.cs`
Ứng dụng sử dụng vòng lặp điều phối để hỗ trợ cơ chế đăng nhập và **đăng xuất quay về màn hình đăng nhập** mượt mà:
```csharp
while (true)
{
    using (var loginForm = new FrmLogin())
    {
        if (loginForm.ShowDialog() != DialogResult.OK || loginForm.LoggedInUser == null)
        {
            break; // Thoát ứng dụng nếu hủy đăng nhập
        }

        using (var mainForm = new FrmMain(loginForm.LoggedInUser))
        {
            Application.Run(mainForm);
            if (!mainForm.IsLoggedOut)
            {
                break; // Thoát hẳn nếu người dùng đóng cửa sổ
            }
        }
    }
}
```

### 4.2. Cơ chế mở Form con MDI không mở trùng lặp
Trong `FrmMain`, phương thức generic `OpenChildForm<T>()` duyệt qua tập hợp `this.MdiChildren`. Nếu Form cùng kiểu đã mở thì chỉ kích hoạt lại:
```csharp
public void OpenChildForm<T>() where T : Form, new()
{
    foreach (Form child in this.MdiChildren)
    {
        if (child is T)
        {
            child.Activate();
            if (child.WindowState == FormWindowState.Minimized)
                child.WindowState = FormWindowState.Normal;
            return;
        }
    }

    T newChild = new T();
    newChild.MdiParent = this;
    newChild.WindowState = FormWindowState.Maximized;
    newChild.Show();
}
```

### 4.3. Quản lý cửa sổ con MDI (MDI Window Layouts)
Hệ thống menu "Cửa sổ" cung cấp các lệnh sắp xếp layout cửa sổ trực quan:
- `LayoutMdi(MdiLayout.Cascade)`: Xếp tầng nối tiếp.
- `LayoutMdi(MdiLayout.TileHorizontal)`: Xếp theo hàng ngang.
- `LayoutMdi(MdiLayout.TileVertical)`: Xếp theo cột dọc.
- `CloseAll`: Đóng toàn bộ các cửa sổ con đang mở.

---

## 5. Trả lời chi tiết 5 câu hỏi nộp kèm (Mục 10 yêu cầu)

### Câu 1: SDI và MDI khác nhau như thế nào?
- **SDI (Single Document Interface - Giao diện đơn tài liệu)**:
  - Mỗi cửa sổ ứng dụng là một cửa sổ độc lập trên màn hình desktop và sở hữu thanh tiêu đề riêng, xuất hiện độc lập trên Taskbar của Windows.
  - Mỗi phiên làm việc chỉ hiển thị một màn hình/tài liệu tại một thời điểm. Muốn làm việc với tài liệu khác thường phải mở một cửa sổ hoàn toàn mới hoặc thay thế nội dung cửa sổ hiện tại.
  - *Ví dụ*: Notepad, Paint, Calculator.
- **MDI (Multiple Document Interface - Giao diện đa tài liệu)**:
  - Ứng dụng bao gồm **một cửa sổ cha (Parent Form)** đóng vai trò là khung chứa (Container với `IsMdiContainer = true`).
  - Toàn bộ **các cửa sổ con (Child Forms)** được mở, hiển thị, di chuyển và thu phóng hoàn toàn bên trong vùng làm việc của cửa sổ cha (`child.MdiParent = this`), không bao giờ thoát ra ngoài Desktop.
  - Cho phép người dùng làm việc đồng thời với nhiều danh mục (như vừa quản lý sản phẩm vừa quản lý khách hàng) trên cùng một không gian làm việc nhất quán.
  - *Ví dụ*: Visual Studio (khu vực soạn thảo code), Adobe Photoshop (bản truyền thống), ứng dụng `ShopManagerMini`.

### Câu 2: Vì sao Form đăng nhập nên dùng `ShowDialog()`?
- `ShowDialog()` hiển thị form dưới dạng **hộp thoại phương thái (Modal Dialog)**:
  1. **Khóa tương tác ngoài**: Người dùng không thể tương tác với bất kỳ cửa sổ nào khác của ứng dụng cho tới khi Form đăng nhập được đóng lại hoặc xác thực xong. Điều này đảm bảo an toàn truy cập, ngăn người dùng bỏ qua bước xác thực để can thiệp vào dữ liệu bên trong.
  2. **Tạm dừng luồng thực thi (Blocking Execution)**: Lệnh gọi `ShowDialog()` sẽ chặn dòng lệnh tiếp theo chạy cho đến khi Form đóng lại.
  3. **Trả về giá trị `DialogResult`**: Giúp mã gọi tại `Program.cs` dễ dàng kiểm tra kết quả trả về (`DialogResult.OK` hay `DialogResult.Cancel`) để quyết định xem có tiếp tục nạp Form chính (`FrmMain`) hay kết thúc ứng dụng.

### Câu 3: Trong bài lab này, dữ liệu user được truyền từ `FrmLogin` sang `FrmMain` bằng cách nào?
- Dữ liệu user được truyền kết hợp thông qua **Thuộc tính công khai (Public Property)** và **Hàm khởi tạo có tham số (Parameterized Constructor)**:
  1. Khi người dùng nhập đúng tài khoản tại `FrmLogin`, thông tin người dùng được gán vào thuộc tính:
     ```csharp
     public User LoggedInUser { get; private set; }
     ```
     Sau đó form đặt `DialogResult = DialogResult.OK` và đóng lại.
  2. Tại `Program.cs`, sau khi `loginForm.ShowDialog() == DialogResult.OK`, mã lấy đối tượng `loginForm.LoggedInUser` và truyền vào constructor của `FrmMain`:
     ```csharp
     using (var mainForm = new FrmMain(loginForm.LoggedInUser))
     {
         Application.Run(mainForm);
     }
     ```
  3. Tại `FrmMain`, constructor tiếp nhận đối tượng `User` và lưu trữ vào thuộc tính `CurrentUser`:
     ```csharp
     public FrmMain(User user)
     {
         CurrentUser = user;
         InitializeComponent();
     }
     ```
  4. Trong sự kiện `FrmMain_Load`, thông tin này được lấy ra hiển thị lên thanh `StatusStrip`:
     ```csharp
     lblUserInfo.Text = $"Người dùng: {CurrentUser.FullName} | Vai trò: {CurrentUser.Role}";
     ```

### Câu 4: Nếu người dùng bấm menu sản phẩm nhiều lần, chương trình xử lý như thế nào để không mở trùng Form?
- Để ngăn việc mở nhiều bản sao của cùng một Form con, chương trình duyệt qua mảng `this.MdiChildren` của Form chính:
  ```csharp
  foreach (Form child in this.MdiChildren)
  {
      if (child is T) // Kiểm tra nếu form con đúng kiểu T đang mở
      {
          child.Activate(); // Đưa form đang có lên trước và lấy tiêu điểm
          if (child.WindowState == FormWindowState.Minimized)
          {
              child.WindowState = FormWindowState.Normal;
          }
          return; // Kết thúc hàm, không khởi tạo form mới
      }
  }
  // Chỉ khi chưa tồn tại form con loại này thì mới tạo mới
  T newChild = new T();
  newChild.MdiParent = this;
  newChild.Show();
  ```
- Nhờ cơ chế trên, khi người dùng bấm menu "Quản lý sản phẩm" nhiều lần, ứng dụng chỉ kích hoạt Form đang mở mà không tốn tài nguyên tạo thêm Form mới.

### Câu 5: Khi nào nên dùng constructor, khi nào nên dùng property để truyền dữ liệu giữa các Form?
- **Nên dùng Constructor**:
  - Khi dữ liệu truyền là **bắt buộc (Mandatory)** để Form con có thể tồn tại và hoạt động đúng logic (áp dụng nguyên lý *Dependency Injection*).
  - Đảm bảo tính toàn vẹn và bất biến (Immutable) của dữ liệu ngay từ lúc đối tượng Form được cấp phát bộ nhớ.
  - Ngăn ngừa tình trạng Form hiển thị lên mà dữ liệu cần thiết vẫn còn mang giá trị `null`.
  - *Ví dụ*: `FrmMain(User user)` buộc phải có đối tượng `User` mới khởi tạo màn hình làm việc; hoặc `FrmProductDetail(Product product)` bắt buộc có sản phẩm mới hiển thị chi tiết được.
- **Nên dùng Property**:
  - Khi dữ liệu truyền là **tùy chọn (Optional)**, có thể gán hoặc không gán mà Form vẫn hoạt động bình thường.
  - Khi cần truyền dữ liệu **sau khi Form đã được khởi tạo** (trong quá trình Form đang chạy).
  - Khi cần **lấy dữ liệu trả về từ Form con** sau khi Form con đó đóng lại (như `loginForm.LoggedInUser`).
  - Khi làm việc với các cơ chế tạo Form tự động, generic hoặc qua Form Factory (nơi chỉ gọi được constructor mặc định `new()`).

---

## 6. Hướng dẫn biên dịch và kiểm thử

### Bằng Visual Studio
1. Mở file solution `ShopManagerMini.sln` hoặc `ShopManagerMini.slnx`.
2. Biên dịch bằng tổ hợp phím `Ctrl + Shift + B`.
3. Chạy ứng dụng bằng `F5` hoặc `Ctrl + F5`.

### Bằng MSBuild qua dòng lệnh
```powershell
& "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" "Lab07\ShopManagerMini\ShopManagerMini.csproj" /t:Build /p:Configuration=Debug
```
File thực thi nằm tại: `Lab07\ShopManagerMini\bin\Debug\ShopManagerMini.exe`.
