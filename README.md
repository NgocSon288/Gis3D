# Gis3D
Đồ án Hệ thống thông tin địa lý 3 chiều

## Cài đặt môi trường
- Cài đặt DotNet 5.0 tại https://dotnet.microsoft.com/en-us/download/dotnet/5.0 

## Khởi chạy chương trình
1. Clone code tại https://github.com/NgocSon288/Gis3D
2. Thiết lập dữ liệu gis từ file backup
	- Sử dụng file data.bak để restore dữ liệu vào SQL Server
3. Sửa lại file Gis3D/WebApp/WebApp/appsettings.json
	- Trỏ tới Server của SQL đã restore
4.  Mở terminal tại thư mục Gis3D/WebApp/WebApp/
	- Dùng lệnh dotnet run để khởi chạy Server. Lúc này sẽ có một Website được mở lên, đây là trang web có người quản trị. Đồng thời đây cũng là  Server cung cấp Api cho Client (Gis)
3. Mở file Gis3D/Client/src/index.html để chạy trang web phía Client (Gis)
