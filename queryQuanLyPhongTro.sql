CREATE DATABASE db_QuanLyPhongTro
Go

USE db_QuanLyPhongTro
Go

Create Table tb_DienTich (
	IdDienTich int Identity(1,1) Primary Key,
	DienTich float Not Null Unique Check (DienTich Between 12 And 25),
	MaDienTich As 'dt' + Convert(nchar(12),IdDienTich) Persisted
)
Go

Create Table tb_TrangThaiPhong (
	IdTrangThaiPhong int Identity(1,1) Primary Key,
	TrangThaiPhong nvarchar(300) Not Null Unique,
	MaTrangThaiPhong As 'ttp' + Convert(nchar(12),IdTrangThaiPhong) Persisted
)
Go

Create Table tb_LoaiPhong (
	IdLoaiPhong int Identity(1,1) Primary Key,
	LoaiPhong nvarchar(300) Not Null Unique,
	MaLoaiPhong As 'lp' + Convert(nchar(12),IdLoaiPhong) Persisted
)
Go


Create Table tb_DonGiaPhong (
	IdDonGiaPhong int Identity(1,1) Primary Key,
	DonGia decimal Not Null,
	id_DonGia_DienTich int Not Null,
	id_DonGia_LoaiPhong int Not Null,
	Foreign Key(id_DonGia_DienTich) references tb_DienTich(IdDienTich),
	Foreign Key(id_DonGia_LoaiPhong) references tb_LoaiPhong(IdLoaiPhong),
	MaDonGiaPhong As 'dgp' + Convert(nchar(12),IdDonGiaPhong) Persisted
)
Go



Create Table tb_Phong (
	IdPhong int Identity(1,1) Primary Key,
	TenPhong nvarchar(300) Not Null,
	id_Phong_TrangThaiPhong int references tb_TrangThaiPhong(IdTrangThaiPhong) Not Null,
	id_Phong_DonGia int references tb_DonGiaPhong(IdDonGiaPhong) Not Null,
	MaPhong As 'ph' + Convert(nchar(12),IdPhong) Persisted

)
Go


Create Table tb_KhachTro (
	IdKhachTro int Identity(1,1) Primary Key,
	CCCD nchar(12) unique Check(CCCD Like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	HoTen nvarchar(200) Check(HoTen Like N'[^UuEeOoAaIiYyWwRrZz]% [^UuEeOoAaIiYyWwRrZz]% [^EeOoIiYyWwRrZz]%'
		Or HoTen Like N'[^UuEeOoAaIiYyWwRrZz]% [^UuEeOoAaIiYyWwRrZz]% [^UuEeOoAaIiYyWwRrZz]% [^EeOoIiYyWwRrZz]%'
		Or HoTen Like N'[^UuEeOoAaIiYyWwRrZz]% [^UuEeOoAaIiYyWwRrZz]% [^UuEeOoAaIiYyWwRrZz]% [^UuEeOoAaIiYyWwRrZz]% [^EeOoIiYyWwRrZz]%'
	),
	SoDienThoai nchar(10) unique Check(SoDienThoai Like '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	NamSinh int Check (NamSinh Between 1950 And Year(GetDate())),
	QueQuan nvarchar(300),
	NgheNghiep nvarchar(300),
	id_KhachTro_Phong int references tb_Phong(IdPhong) Not Null,
	MaKhachTro As 'kh' + Convert(nchar(12),IdKhachTro) Persisted,
	TenDangNhap nvarchar(500) Not Null Unique,
)
Go

Create Table tb_ThongTinNo (
	IdThongTinNo int Identity(1,1) Primary Key,
	SoTienNo decimal Not Null,
	id_ThongTinNo_Phong int references tb_Phong(IdPhong) Not Null Unique,
	MaThongTinNo As 'n' + Convert(nchar(12),IdThongTinNo) Persisted

)
Go

--1 là Quá kì hạn mà chưa thanh toán(giá trị mặc định của cột TrangThaiHoaDon)
--2 là Quá kì hạn mà chưa thanh toán đủ(số tiền thanh toán < SoTienPhaiThanhToanCua Hoa Don)
--3 là Thanh toán đủ và trong kì hạn
--4 là hóa đơn của các phòng trước và hiện chỉ để xem
Create Table tb_HoaDon (
	IdHoaDon int Identity(1,1) Primary Key,
	id_HoaDon_Phong int references tb_Phong(IdPhong) Not Null,
	NgayXuatHoaDon Date Not Null,
	KiHanThanhToan Date,
	SoDien int Not Null,
	SoNuoc int Not Null,
	SoTienConLaiPhaiThanhToan decimal,
	TongTienPhaiThanhToan decimal,
	MaHoaDon As 'hd' + Convert(nchar(12),IdHoaDon) Persisted,
	TrangThaiHoaDon tinyint Default 1
	--Phải ở table level mới không lỗi
)
Go
Alter Table tb_HoaDon
Add Constraint chk_KiHanSauHonNgayXuat Check(KiHanThanhToan > NgayXuatHoaDon)
Go
--thêm trạng thái là 4
Alter Table tb_HoaDon
Add Constraint chk_TapGiaTriTrangThai Check(TrangThaiHoaDon In (1,2,3,4))
Go

Create Table tb_LanThanhToan (
	IdLanThanhToan int Identity(1,1) Primary Key,
	id_ThanhToan_KhachTro int references tb_KhachTro(IdKhachTro) On Delete Set Null Null ,
	id_ThanhToan_HoaDon int references tb_HoaDon(IdHoaDon) Not Null,
	SoTienTra decimal Not Null,
	NgayThanhToan Date Not Null,
	MaLanThanhToan As 'tt' + Convert(nchar(12),IdLanThanhToan) Persisted
)
Go


Create Function func_SoKhachThuocPhong(@IdPhong int)
Returns int
Begin 
	Declare @SoLuongKhach int
	Select @SoLuongKhach = Count(kt.IdKhachTro)
	From tb_KhachTro kt Where kt.id_KhachTro_Phong = @IdPhong

	Return @SoLuongKhach
End
Go


Create Trigger trg_GioiHanSoKhach On tb_KhachTro
After Insert, Update 
As
Begin
	Declare @IdPhong int
	Select @IdPhong = ins.id_KhachTro_Phong
	From inserted ins

	If dbo.func_SoKhachThuocPhong(@IdPhong) < 4 
		Begin
			--Cột identity và computed không thể thêm vào được vì nó được sinh ra tự động
			If Not Exists(Select * From deleted) --Hanh Động chắc chắn là insert
				Begin			
					Print N'Thêm khách không làm đầy phòng rb1'
				End
			Else			
				Print N'Sửa phòng khách ở không làm đầy phòng mới/cũ đó rb1'
		End
	Else
		If dbo.func_SoKhachThuocPhong(@IdPhong) > 4
			Begin
				Print N'Không thêm khách được vì phòng đã đầy: 4 người rb1'
				Rollback
			End
End
Go


Create Trigger trg_ToanVenTrangThaiPhong On tb_KhachTro
After Insert,Update, Delete
As
Begin
	Declare @IdPhong int, @HanhDong as char(1)
	Set @HanhDong = (Case When Exists(Select * From inserted) And Exists(Select Top 1 * From deleted)
						  Then 'U' -- Set @HanhDong thực hiện là update
						  When Exists(Select* From inserted)
						  Then 'I'
						  When Exists(Select * From deleted)
						  Then 'D'
					 End)

	If @HanhDong = 'I'
		Begin 
			Select @IdPhong = ins.id_KhachTro_Phong
			From inserted ins

			If dbo.func_SoKhachThuocPhong(@IdPhong) = 4 
				Begin 
					Update tb_Phong
					Set id_Phong_TrangThaiPhong = 3 --3 là id của trạng thái đã đầy
					Where IdPhong = @IdPhong
					Print N'Phòng đã đầy sau khi khách mới vào'
				End			
			Else If dbo.func_SoKhachThuocPhong(@IdPhong) < 4
				Begin 
					Update tb_Phong
					Set id_Phong_TrangThaiPhong = 2
					Where IdPhong = @IdPhong
				End	

		End
	Else
		Begin 
			If @HanhDong = 'D'
				Begin 
					Select @IdPhong = del.id_KhachTro_Phong
					From deleted del

					If dbo.func_SoKhachThuocPhong(@IdPhong) = 0 
						Begin 
							Print N'Phòng đã trống sau khi khách đi'
							Update tb_Phong
							Set id_Phong_TrangThaiPhong = '1' --1 là id của trạng thái trống
							Where IdPhong = @IdPhong
						End	 	
					Else If dbo.func_SoKhachThuocPhong(@IdPhong) > 4
						Begin 
							Update tb_Phong
							Set id_Phong_TrangThaiPhong = 2	
							Where IdPhong = @IdPhong
						End	
				End
			Else -- Hanh Dong chắc chắn là update
				Begin
					Declare @IdPhongMoi int, @IdPhongCu int
					Select @IdPhongMoi = ins.id_KhachTro_Phong, @IdPhongCu = del.id_KhachTro_Phong
					From inserted ins, deleted del

					If @IdPhongCu = @IdPhongMoi
						Return
					
					If dbo.func_SoKhachThuocPhong(@IdPhongMoi) = 4
						Begin 
							Update tb_Phong
							Set id_Phong_TrangThaiPhong = 3 --3 là id của trạng thái đã đầy
							Where IdPhong = @IdPhong
							Print N'Phòng đã đầy sau khi khách mới vào'
						End	
					Else
						Begin
							Update tb_Phong
							Set id_Phong_TrangThaiPhong = 2
							Where IdPhong = @IdPhong
							Print N'Phòng vẫn có người ở sau khi khách vô'
						End

					If dbo.func_SoKhachThuocPhong(@IdPhongCu) = 0
						Begin 
							Update tb_Phong
							Set id_Phong_TrangThaiPhong = '1' --1 là id của trạng thái trống
							Where IdPhong = @IdPhong
							Print N'Phòng đã trống sau khi khách đi'
						End	
					Else
						Begin
							Update tb_Phong
							Set id_Phong_TrangThaiPhong = 2
							Where IdPhong = @IdPhong
							Print N'Phòng vẫn có người ở sau khi khách đi'
						End

				End
		End
End
Go


Create Trigger trg_ToanVenPhongDcThanhToan On tb_LanThanhToan
After Insert
As
Begin
	Declare @IdKhachTro int, @IdHoaDon int,
			@IdPhongKhachO int, @IdPhongDcThanhToanHoaDon int
	Select @IdKhachTro = ins.id_ThanhToan_KhachTro, @IdHoaDon = ins.id_ThanhToan_HoaDon
	From inserted ins


	Select @IdPhongKhachO = kt.id_KhachTro_Phong
	From tb_KhachTro kt Where kt.IdKhachTro = @IdKhachTro

	Select @IdPhongDcThanhToanHoaDon = hd.id_HoaDon_Phong
	From tb_HoaDon hd Where hd.IdHoaDon = @IdHoaDon

	If @IdPhongKhachO != @IdPhongDcThanhToanHoaDon
		Begin
			Print N'Khách thanh toán cho sai phòng'
			Rollback
		End
End
Go


Create Procedure proc_GanNoMoiHoacXoaNo
	@NoMoi decimal(18, 0), @IdPhong int
As
Begin
	If @NoMoi = 0 
		Delete From tb_ThongTinNo Where @IdPhong = tb_ThongTinNo.id_ThongTinNo_Phong;
	Else
		Update tb_ThongTinNo
		Set SoTienNo = @NoMoi 
		Where @IdPhong = tb_ThongTinNo.id_ThongTinNo_Phong;
End
Go

--Ngày thanh toán hợp lệ khi ngày đó sau ngày xuất hóa đơn và nằm trong kì hạn thanh toán
Create Trigger trg_NgayThanhToanHopLe On tb_LanThanhToan
After Insert 
As
Begin
	Declare @NgayThanhToan Date, @IdHoaDonThanhToan int,@KiHanThanhToanHoaDonHienTai Date,@NgayXuatHoaDon Date
	
	Select @NgayThanhToan = ins.NgayThanhToan, @IdHoaDonThanhToan = ins.id_ThanhToan_HoaDon
	From inserted ins

	Select @KiHanThanhToanHoaDonHienTai = hd.KiHanThanhToan,@NgayXuatHoaDon = hd.NgayXuatHoaDon
	From tb_HoaDon hd Where hd.IdHoaDon = @IdHoaDonThanhToan

	If @NgayThanhToan > @KiHanThanhToanHoaDonHienTai Or @NgayThanhToan < @NgayXuatHoaDon
		Begin
			Print N'Đã quá kì hạn nên không thể thanh toán cho hóa đơn này hoặc ngày thanh toán trước ngày xuất hóa đơn !!?'
			Rollback
		End
End
Go


Create Trigger trg_TinhSoTienPhaiTraChoHoaDon On tb_HoaDon
After Insert
As
	Begin
		Declare @IdPhongPhaiThanhToan int,@IdDonGiaCuaPhong int,@IdHoaDon int,
				@DonGia decimal, @SoDien int,@SoNuoc int, @TienThanhToanHoaDon decimal

		Select @IdHoaDon = ins_Hd.IdHoaDon, @IdPhongPhaiThanhToan = ins_Hd.id_HoaDon_Phong,
			   @SoDien = ins_Hd.SoDien, @SoNuoc = ins_Hd.SoNuoc
		From inserted ins_Hd

		Select @IdDonGiaCuaPhong = p.id_Phong_DonGia
		From tb_Phong p Where p.IdPhong = @IdPhongPhaiThanhToan

		Select @DonGia = dg.DonGia
		From tb_DonGiaPhong dg Where dg.IdDonGiaPhong = @IdDonGiaCuaPhong

		Set @TienThanhToanHoaDon = @DonGia + @SoDien * 2500 + @SoNuoc * 5000

		--Cập nhật bảng hóa đơn tại bản ghi vừa thêm,tong tiền phải thanh toán, tiền còn lại phải thanh toán
		Update tb_HoaDon
		Set TongTienPhaiThanhToan = @TienThanhToanHoaDon,SoTienConLaiPhaiThanhToan = @TienThanhToanHoaDon
		Where IdHoaDon = @IdHoaDon

		--Cập nhật lại cứ mỗi khi xuất hóa đơn sẽ tự cộng vào nợ, mỗi lần thanh toán thì nợ sẽ bớt dần
		--hoặc nếu hiện tại không có nợ(do tháng trước thanh toán hết nên xóa) thì tạo mới
		If Not Exists(Select Top 1 * From tb_ThongTinNo ttn Where ttn.id_ThongTinNo_Phong = @IdPhongPhaiThanhToan)
			Begin
				Insert Into tb_ThongTinNo(SoTienNo,id_ThongTinNo_Phong) Values(@TienThanhToanHoaDon,@IdPhongPhaiThanhToan)
			End
		Else
		--Hiện đang còn nợ từ các tháng trước
			Begin
				Declare @SoTienDangNo decimal,@TienNoMoi decimal
				Select @SoTienDangNo = ttn.SoTienNo From tb_ThongTinNo ttn Where ttn.id_ThongTinNo_Phong = @IdPhongPhaiThanhToan
				Set @TienNoMoi = @SoTienDangNo + @TienThanhToanHoaDon
				Exec dbo.proc_GanNoMoiHoacXoaNo @TienNoMoi,@IdPhongPhaiThanhToan
			End
	

	End
Go


Create Trigger trg_CapNhatTrangThaiHoaDon On tb_LanThanhToan
After Insert
As
	Begin
		Declare @SoTienTra decimal,@SoTienPhaiThanhToan decimal,
				@IdHoaDon int

		Select @SoTienTra = ins_TT.SoTienTra, @IdHoaDon = ins_TT.id_ThanhToan_HoaDon
		From inserted ins_TT

		Select @SoTienPhaiThanhToan = hd.SoTienConLaiPhaiThanhToan
		From tb_HoaDon hd Where hd.IdHoaDon = @IdHoaDon

		--Update trạng thái hóa đơn là 2, không cần kiểm tra ngày thanh toán vì đã có trigger khác đảm bảo ngày thanh toán phải lớn hơn ngày xuất hóa đơn
		--Cập nhật lại cả số tiền cần phải trả
		--Nên cập tại trigger này để đảm bảo khi kiểm tra thì kiểm tra đúng số
		If @SoTienTra < @SoTienPhaiThanhToan 
			Begin
				Update tb_HoaDon
				Set TrangThaiHoaDon = 2,SoTienConLaiPhaiThanhToan = @SoTienPhaiThanhToan - @SoTienTra
				Where IdHoaDon = @IdHoaDon
			End
		--Update trạng thái hóa đơn là 3 và chắc chắn số tiền còn lại phải thanh toán là 0 vì trả nhiều hơn rồi
		Else If @SoTienTra >= @SoTienPhaiThanhToan
			Begin
				Update tb_HoaDon
				Set TrangThaiHoaDon = 3,SoTienConLaiPhaiThanhToan = 0
				Where IdHoaDon = @IdHoaDon
			End
	End
Go

 
Create Function func_NoPhong(@IdPhong int)
Returns decimal
Begin
	Declare @TongTienNo decimal
	Select @TongTienNo = ttn.SoTienNo
	From tb_ThongTinNo ttn Where ttn.id_ThongTinNo_Phong = @IdPhong

	Return @TongTienNo
End
Go

--Hàm đếm số hóa đơn có mã trạng thái là 2 trong 6 tháng gần đây nhất của 1 phòng
Create Function func_SoLanThanhToanThieuSauThang(@IdPhong int)
Returns tinyint
Begin
	Declare @SoLanDongThieu tinyint
	Select @SoLanDongThieu = Count(hd.IdHoaDon)
	From tb_HoaDon hd
	Where DATEDIFF(month,hd.NgayXuatHoaDon,GETDATE()) <= 6 And hd.TrangThaiHoaDon = 2 And hd.id_HoaDon_Phong = @IdPhong
	Return @SoLanDongThieu
End
Go


--xóa khách thì xóa tất cả các lần thanh toán ứng với khách đó
Create Trigger trg_ToanVenTienThanhToan On tb_LanThanhToan
After Insert
As
Begin
	Declare @TienThanhToan decimal(18,0),@SoTienConLaiHoaDon decimal(18,0), @SoTienDangNo decimal(18,0),
	@IdHoaDon int, @IdPhongDcThanhToan int, @IdLanThanhToanNay int		
	Select @TienThanhToan = ins.SoTienTra, @IdHoaDon = ins.id_ThanhToan_HoaDon,@IdLanThanhToanNay = ins.IdLanThanhToan
	From inserted ins

	Select @IdPhongDcThanhToan = hd.id_HoaDon_Phong,@SoTienConLaiHoaDon = hd.SoTienConLaiPhaiThanhToan
	From tb_HoaDon hd Where hd.IdHoaDon = @IdHoaDon

	--Nếu phòng được thanh toán không có nợ thì sao
	--Bây giờ số tiền đang nợ đã bao gồm tiền còn cần phải trả của hóa đơn tháng đó
	Select  @SoTienDangNo = n.SoTienNo
	From tb_ThongTinNo n Where n.id_ThongTinNo_Phong = @IdPhongDcThanhToan

	If @TienThanhToan > @SoTienDangNo
		Begin
			Print N'Trả dư tiền rồi !!?'
			Rollback
		End
	Else 
		Begin
			--Xóa thông tin nợ hiện tại của phòng đó
			If @TienThanhToan = @SoTienDangNo
				Begin
				Print N'Đã thanh toán hết hóa đơn tháng này và thanh toán hết nợ'
					Exec proc_GanNoMoiHoacXoaNo 0,@IdPhongDcThanhToan
				End
			Else
				Begin
					Declare @TienNoMoi decimal
					If @TienThanhToan > @SoTienConLaiHoaDon And @TienThanhToan < @SoTienDangNo
						Begin
							Set @TienNoMoi = @SoTienDangNo - @TienThanhToan
							Print N'Đã thanh toán hết hóa đơn tháng này nhưng vẫn còn nợ'
							Exec proc_GanNoMoiHoacXoaNo @TienNoMoi, @IdPhongDcThanhToan
						End
					--Cũng vẫn cập nhật nợ vì nợ là bao gồm cả số tiền còn lại cần thanh toán của hóa đơn nên cứ mỗi lần thanh toán đều cần phải cập nhật nợ
					Else If @TienThanhToan < @SoTienConLaiHoaDon
						Begin
							Set @TienNoMoi = @SoTienDangNo - @TienThanhToan
							Print N'Đã thanh toán nhưng chưa hết hóa đơn tháng này'
							Exec proc_GanNoMoiHoacXoaNo @TienNoMoi, @IdPhongDcThanhToan
						End
				End
			--Cập nhật thông tin nợ của phòng đó
		End
End
Go



Create Procedure proc_XoaCacKhachThuocPhong(@IdPhong int)
As
Begin
	Delete From tb_KhachTro 
	Where id_KhachTro_Phong = @IdPhong
End
Go


Create Proc proc_DuoiKhachTroViPhamNoiQuy
As
Begin
	Declare @IdPhongDangXet int	
	--Khởi tạo Cursor sẽ là danh sách các id của các phòng
	Declare IdPhong_Cursor Cursor For
		Select IdPhong From tb_Phong

	--Mở cursor ra để lặp qua từng mã phòng trong danh sách
	Open IdPhong_Cursor

	--Lấy hàng dữ liệu đầu trong cursor ra và gán cho biến @IdPhongDangXet
	Fetch Next From IdPhong_Cursor Into @IdPhongDangXet

	--Lặp qua từng id phòng, điều kiện dừng là việc fetch thất bại
	While @@FETCH_STATUS = 0
	Begin
		--Nếu vi phạm nội quy -> Xóa Tất cả khách thuộc phòng đó và các khoản nợ hiện tại của phòng
		If dbo.func_NoPhong(@IdPhongDangXet) > 2000000 Or dbo.func_SoLanThanhToanThieuSauThang(@IdPhongDangXet) > 3
		Begin
			Exec proc_XoaCacKhachThuocPhong @IdPhongDangXet
			Exec proc_GanNoMoiHoacXoaNo 0, @IdPhongDangXet
			--Thêm để cập nhật các hóa đơn của phòng hiện tại,xem lại trạng thái
			Update tb_HoaDon Set TrangThaiHoaDon = 4 Where TrangThaiHoaDon !=4 And id_HoaDon_Phong = @IdPhongDangXet
		End
		Fetch Next From IdPhong_Cursor Into @IdPhongDangXet
	End

	Close IdPhong_Cursor
    DeAllocate IdPhong_Cursor
End
Go



Create Proc proc_XoaMotKhachTro(@IdKhach int)
As
Begin 
Delete From tb_KhachTro 
Where IdKhachTro=@IdKhach
End 
Go

Create Proc proc_XuatHoaDonPhong(
	@IdPhongXuatHoaDon int,
	@NgayXuatHoaDon Date,
	@KiHanThanhToan Date,
	@SoDien int,
	@SoNuoc int	
)
As 
Begin 
Insert Into tb_HoaDon (id_HoaDon_Phong,NgayXuatHoaDon,KiHanThanhToan,SoDien,SoNuoc) 
		Values (@IdPhongXuatHoaDon, @NgayXuatHoaDon,@KiHanThanhToan,@SoDien,@SoNuoc)
End
Go



--Chi dc thanh toan cho hoa don van con tien phai tra
Create Procedure proc_ThanhToanHoaDon
	@IdKhachThanhToan int,
	@IdHoaDonThanhToan int,
	@SoTienThanhToan decimal,
	@NgayThanhToan Date
As
Begin
	Insert Into tb_LanThanhToan(id_ThanhToan_KhachTro,id_ThanhToan_HoaDon,SoTienTra,NgayThanhToan) 
	Values (@IdKhachThanhToan,@IdHoaDonThanhToan,@SoTienThanhToan,@NgayThanhToan)
End
Go


Create Procedure proc_ThemKhachTro
	@CCCD nchar(12),
	@Hoten nvarchar(200),
	@Sdt nchar(10),
	@NamSinh int,
	@QueQuan nvarchar(300),
	@Nghe nvarchar(300),
	@idPhong int,
	@TenDangNhap varchar(500),
	@MatKhau nvarchar(Max)
As
Begin Tran
	Insert Into tb_KhachTro(CCCD, HoTen, SoDienThoai, NamSinh, QueQuan, NgheNghiep, id_KhachTro_Phong, TenDangNhap) 
	Values (@CCCD,@Hoten,@Sdt,@NamSinh,@QueQuan,@Nghe,@idPhong, @TenDangNhap)

	Declare @Sql nvarchar(Max)
	Set @Sql = 'Create Login ' + @TenDangNhap + 
               ' With Password = ''' + @MatKhau + '''; ' +
           'Create User user_' + @TenDangNhap + ' For Login ' + @TenDangNhap
	Exec (@Sql)
	Declare @TenUser varchar(505)
	Set @TenUser = Concat('user_', @TenDangNhap)
	Exec sp_addrolemember @rolename= 'role_KhachTro',@membername= @TenUser
	--thay end bằng commit và cho bắt đầu begin tran vì khi test có lỗi ko insert được nhưng lại tạo login được
	If @@ERROR = 0
		Begin
			Commit
		End
	Else 
		Begin
			Print 'Xảy ra lỗi trong proc_ThemKhachTro'
			Rollback
		End
Go


Create Proc proc_CapNhatThongTinKhachTro (
    @idKhachTro int,
    @cccd nchar(12),
    @hoTen nvarchar(200),
    @sdt nchar(10),
    @namSinh int,
    @queQuan nvarchar(300),
    @ngheNghiep nvarchar(300)
)
As
Begin
Update tb_KhachTro
Set 
	CCCD = @cccd,
	HoTen = @hoTen,
	SoDienThoai = @sdt,
	NamSinh = @namSinh,
	QueQuan = @queQuan,
	NgheNghiep = @ngheNghiep
Where IdKhachTro = @idKhachTro
End
Go


Create Proc proc_CapNhatDonGia (@idDonGiaPhong int, @donGia DECIMAL)
As
Begin
Update tb_DonGiaPhong
Set DonGia = @donGia
Where IdDonGiaPhong = @idDonGiaPhong
End
Go




Create Function func_CacHoaDonThanhToanDuocCuaPhong(@IdPhong int)
Returns Table
As Return (Select * From tb_HoaDon hd
		Where hd.TrangThaiHoaDon In (1,2) And (GETDATE() Between hd.NgayXuatHoaDon And hd.KiHanThanhToan) And hd.id_HoaDon_Phong = @IdPhong)
Go



--07/11/2022
--Tạo sẵn role của khách trọ trong databse có các quyền của khách trọ
--Chỉnh sửa proc_ThemKhachTro
--Them cot TenDangNhap(unique) vào bảng khách trọ
--Tạo login với tên là TenDangNhap và MatKhau(admin đặt)
--Tạo user gắn với login đó
--Gán role khách trọ cho user vừa tạo
--Nếu xóa khách trọ thì admin phải xóa thủ công login user của khách trọ đó
--Hàm Đăng nhập trả về IdKhachTro(nếu đăng nhập thành công thì trong bảng tb_KhachTro có 1 khách trọ có cột TenDangNhap giống tham số truyền vào)
--Nhận vào TenDangNhap và MatKhau -> thay đổi conn String(c#) -> kết nối với SSMS bằng login đó
--Truyền vào TenDangNhap và MatKhau và trả về IdKhachTro trong bảng tb_KhachTro

Create Function func_DangNhap(@TenDangNhap nvarchar(Max))
Returns int
Begin
	Declare @IdKhachTroDangNhap int
	Select @IdKhachTroDangNhap = kt.IdKhachTro
	From tb_KhachTro kt
	Where kt.TenDangNhap = @TenDangNhap
	Return @IdKhachTroDangNhap
End
Go


--Tạo login cho admin(có thể không dùng do kết nối = Windows Authentication)
--thêm user gắn với login của admin vào role sysadmin để có mọi quyền hạn trong tất cả database
Create Login admin_QuanLyPhongTro With Password = 'admin'
Create User admin_QLPT For Login admin_QuanLyPhongTro
Exec sp_addsrvrolemember @loginame='admin_QuanLyPhongTro',@rolename='sysadmin'
Go

Create View vw_ThongTinDonGiaPhong As
Select *
From (Select * From tb_DonGiaPhong dgp Inner Join tb_LoaiPhong lp 
			On dgp.id_DonGia_LoaiPhong = lp.IdLoaiPhong) buff1
		Inner Join tb_DienTich dt On buff1.id_DonGia_DienTich = dt.IdDienTich
Go

Create View vw_ThongTinPhong As
Select *
From (Select * From tb_Phong p Inner Join tb_TrangThaiPhong ttp 
			On p.id_Phong_TrangThaiPhong = ttp.IdTrangThaiPhong) buff2
		Inner Join vw_ThongTinDonGiaPhong buff1 On buff2.id_Phong_DonGia = buff1.IdDonGiaPhong
Go

Create View vw_ThongTinHoaDon As
Select hd.IdHoaDon,hd.MaHoaDon,hd.id_HoaDon_Phong,hd.NgayXuatHoaDon,hd.KiHanThanhToan,hd.SoDien,hd.SoNuoc,hd.TongTienPhaiThanhToan
		,n.SoTienNo,hd.SoTienConLaiPhaiThanhToan,n.MaThongTinNo,p.IdPhong,p.MaPhong,hd.TrangThaiHoaDon,p.id_Phong_DonGia
From (tb_HoaDon hd inner join tb_Phong p On hd.id_HoaDon_Phong = p.IdPhong) 
			left join tb_ThongTinNo n On p.IdPhong = n.id_ThongTinNo_Phong
--left join vì nếu phòng ko có thông tin nợ thì vẫn phải hiển thị hóa đơn ra
Go

--ko cần left join tb_LanThanhToan vì không còn xóa LanThanhToan mà set null cột id_ThanhToan_KhachTro
--nên sẽ chỉ left join tb_KhachTro
Create View vw_ThongTinThanhToan As
Select vw_tthd.*, tt.IdLanThanhToan,tt.SoTienTra,tt.NgayThanhToan,
		kt.MaKhachTro 'NguoiThanhToan',kt.HoTen,kt.id_KhachTro_Phong 'IdPhongNguoiThanhToanO'
From vw_ThongTinHoaDon vw_tthd inner join tb_LanThanhToan tt On 
		tt.id_ThanhToan_HoaDon = vw_tthd.IdHoaDon left join tb_KhachTro kt On
			tt.id_ThanhToan_KhachTro = kt.IdKhachTro
Go

Use db_QuanLyPhongTro
Go

Create Role role_KhachTro
Grant Select On Object::dbo.vw_ThongTinDonGiaPhong To role_KhachTro
Grant Select On Object::dbo.vw_ThongTinPhong To role_KhachTro
Grant Select On Object::dbo.vw_ThongTinHoaDon To role_KhachTro
Grant Select On Object::dbo.vw_ThongTinThanhToan To role_KhachTro
Grant Select On Object::dbo.tb_KhachTro To role_KhachTro
Grant Execute On Object::dbo.proc_ThanhToanHoaDon To role_KhachTro
Grant Select On Object::dbo.func_CacHoaDonThanhToanDuocCuaPhong To role_KhachTro
Grant Execute On Object::dbo.proc_XoaMotKhachTro To role_KhachTro
Grant Execute On Object::dbo.proc_CapNhatThongTinKhachTro To role_KhachTro
Go

--Code tạo dữ liệu
USE [db_QuanLyPhongTro]
GO
SET IDENTITY_INSERT [dbo].[tb_DienTich] ON 
GO
INSERT [dbo].[tb_DienTich] ([IdDienTich], [DienTich]) VALUES (1, 15.5)
GO
INSERT [dbo].[tb_DienTich] ([IdDienTich], [DienTich]) VALUES (2, 18.2)
GO
INSERT [dbo].[tb_DienTich] ([IdDienTich], [DienTich]) VALUES (3, 25)
GO
SET IDENTITY_INSERT [dbo].[tb_DienTich] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_LoaiPhong] ON 
GO
INSERT [dbo].[tb_LoaiPhong] ([IdLoaiPhong], [LoaiPhong]) VALUES (3, N'Phòng có sẵn nội thất')
GO
INSERT [dbo].[tb_LoaiPhong] ([IdLoaiPhong], [LoaiPhong]) VALUES (2, N'Phòng Thường')
GO
INSERT [dbo].[tb_LoaiPhong] ([IdLoaiPhong], [LoaiPhong]) VALUES (1, N'Phòng Vip')
GO
SET IDENTITY_INSERT [dbo].[tb_LoaiPhong] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_DonGiaPhong] ON 
GO
INSERT [dbo].[tb_DonGiaPhong] ([IdDonGiaPhong], [DonGia], [id_DonGia_DienTich], [id_DonGia_LoaiPhong]) VALUES (1, CAST(550000 AS Decimal(18, 0)), 1, 2)
GO
INSERT [dbo].[tb_DonGiaPhong] ([IdDonGiaPhong], [DonGia], [id_DonGia_DienTich], [id_DonGia_LoaiPhong]) VALUES (2, CAST(650000 AS Decimal(18, 0)), 2, 2)
GO
INSERT [dbo].[tb_DonGiaPhong] ([IdDonGiaPhong], [DonGia], [id_DonGia_DienTich], [id_DonGia_LoaiPhong]) VALUES (3, CAST(700000 AS Decimal(18, 0)), 3, 3)
GO
INSERT [dbo].[tb_DonGiaPhong] ([IdDonGiaPhong], [DonGia], [id_DonGia_DienTich], [id_DonGia_LoaiPhong]) VALUES (4, CAST(750000 AS Decimal(18, 0)), 3, 1)
GO
SET IDENTITY_INSERT [dbo].[tb_DonGiaPhong] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_TrangThaiPhong] ON 
GO
INSERT [dbo].[tb_TrangThaiPhong] ([IdTrangThaiPhong], [TrangThaiPhong]) VALUES (2, N'Có người ở')
GO
INSERT [dbo].[tb_TrangThaiPhong] ([IdTrangThaiPhong], [TrangThaiPhong]) VALUES (3, N'Đầy')
GO
INSERT [dbo].[tb_TrangThaiPhong] ([IdTrangThaiPhong], [TrangThaiPhong]) VALUES (1, N'Trống')
GO
SET IDENTITY_INSERT [dbo].[tb_TrangThaiPhong] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_Phong] ON 
GO
INSERT [dbo].[tb_Phong] ([IdPhong], [TenPhong], [id_Phong_TrangThaiPhong], [id_Phong_DonGia]) VALUES (1, N'Phòng tên 1', 1, 1)
GO
INSERT [dbo].[tb_Phong] ([IdPhong], [TenPhong], [id_Phong_TrangThaiPhong], [id_Phong_DonGia]) VALUES (2, N'Phòng tên 2', 1, 1)
GO
INSERT [dbo].[tb_Phong] ([IdPhong], [TenPhong], [id_Phong_TrangThaiPhong], [id_Phong_DonGia]) VALUES (3, N'Phòng tên 3', 1, 2)
GO
INSERT [dbo].[tb_Phong] ([IdPhong], [TenPhong], [id_Phong_TrangThaiPhong], [id_Phong_DonGia]) VALUES (4, N'Phòng tên 4', 1, 3)
GO
INSERT [dbo].[tb_Phong] ([IdPhong], [TenPhong], [id_Phong_TrangThaiPhong], [id_Phong_DonGia]) VALUES (5, N'Phòng tên 5', 1, 4)
GO
SET IDENTITY_INSERT [dbo].[tb_Phong] OFF

Exec proc_ThemKhachTro N'079202018871', N'Nguyễn Đức Thịnh', N'0389532035', 2002, N'Thái Bình', N'Sinh Viên', 1 , N'thinh', N'123'
Exec proc_ThemKhachTro N'096754345678', N'Nguyễn Đức Hiển', N'0221978645', 2002, N'Kiên Giang', N'Sinh Viên', 2 , N'hien', N'123'
Exec proc_ThemKhachTro N'072611829113', N'Nguyễn Quốc Toàn', N'0367521435', 2002, N'An Giang', N'Sinh Viên', 3 , N'toan', N'123'
Exec proc_ThemKhachTro N'089254321511', N'Phạm Quang Huy', N'0767028708', 2002, N'An Giang', N'Sinh Viên', 4 , N'huy', N'123'




SET IDENTITY_INSERT [dbo].[tb_HoaDon] ON 
GO
--test số hóa đơn vi phạm các hóa đơn phòng 1
INSERT [dbo].[tb_HoaDon] ([IdHoaDon], [id_HoaDon_Phong], [NgayXuatHoaDon], [KiHanThanhToan], [SoDien], [SoNuoc], [SoTienConLaiPhaiThanhToan], [TongTienPhaiThanhToan], [TrangThaiHoaDon]) VALUES (1, 1, CAST(N'2022-04-10' AS Date), CAST(N'2022-05-10' AS Date), 10, 10, CAST(625000 AS Decimal(18, 0)), CAST(625000 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[tb_HoaDon] ([IdHoaDon], [id_HoaDon_Phong], [NgayXuatHoaDon], [KiHanThanhToan], [SoDien], [SoNuoc], [SoTienConLaiPhaiThanhToan], [TongTienPhaiThanhToan], [TrangThaiHoaDon]) VALUES (2, 1, CAST(N'2022-05-15' AS Date), CAST(N'2022-06-15' AS Date), 10, 10, CAST(625000 AS Decimal(18, 0)), CAST(625000 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[tb_HoaDon] ([IdHoaDon], [id_HoaDon_Phong], [NgayXuatHoaDon], [KiHanThanhToan], [SoDien], [SoNuoc], [SoTienConLaiPhaiThanhToan], [TongTienPhaiThanhToan], [TrangThaiHoaDon]) VALUES (3, 1, CAST(N'2022-06-01' AS Date), CAST(N'2022-07-01' AS Date), 10, 10, CAST(625000 AS Decimal(18, 0)), CAST(625000 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[tb_HoaDon] ([IdHoaDon], [id_HoaDon_Phong], [NgayXuatHoaDon], [KiHanThanhToan], [SoDien], [SoNuoc], [SoTienConLaiPhaiThanhToan], [TongTienPhaiThanhToan], [TrangThaiHoaDon]) VALUES (4, 1, CAST(N'2022-08-01' AS Date), CAST(N'2022-09-01' AS Date), 10, 10, CAST(625000 AS Decimal(18, 0)), CAST(625000 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[tb_HoaDon] ([IdHoaDon], [id_HoaDon_Phong], [NgayXuatHoaDon], [KiHanThanhToan], [SoDien], [SoNuoc], [SoTienConLaiPhaiThanhToan], [TongTienPhaiThanhToan], [TrangThaiHoaDon]) VALUES (5, 1, CAST(N'2022-09-01' AS Date), CAST(N'2022-10-09' AS Date), 10, 10, CAST(625000 AS Decimal(18, 0)), CAST(625000 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[tb_HoaDon] ([IdHoaDon], [id_HoaDon_Phong], [NgayXuatHoaDon], [KiHanThanhToan], [SoDien], [SoNuoc], [SoTienConLaiPhaiThanhToan], [TongTienPhaiThanhToan], [TrangThaiHoaDon]) VALUES (6, 1, CAST(N'2022-10-10' AS Date), CAST(N'2022-11-10' AS Date), 10, 10, CAST(625000 AS Decimal(18, 0)), CAST(625000 AS Decimal(18, 0)), 1)
GO

--hóa đơn phòng 2
INSERT [dbo].[tb_HoaDon] ([IdHoaDon], [id_HoaDon_Phong], [NgayXuatHoaDon], [KiHanThanhToan], [SoDien], [SoNuoc], [SoTienConLaiPhaiThanhToan], [TongTienPhaiThanhToan], [TrangThaiHoaDon]) VALUES (7, 2, CAST(N'2022-09-01' AS Date), CAST(N'2022-10-09' AS Date), 10, 10, CAST(625000 AS Decimal(18, 0)), CAST(625000 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[tb_HoaDon] ([IdHoaDon], [id_HoaDon_Phong], [NgayXuatHoaDon], [KiHanThanhToan], [SoDien], [SoNuoc], [SoTienConLaiPhaiThanhToan], [TongTienPhaiThanhToan], [TrangThaiHoaDon]) VALUES (8, 2, CAST(N'2022-10-10' AS Date), CAST(N'2022-11-9' AS Date), 10, 10, CAST(625000 AS Decimal(18, 0)), CAST(625000 AS Decimal(18, 0)), 1)
GO

--hóa đơn phòng 3
INSERT [dbo].[tb_HoaDon] ([IdHoaDon], [id_HoaDon_Phong], [NgayXuatHoaDon], [KiHanThanhToan], [SoDien], [SoNuoc], [SoTienConLaiPhaiThanhToan], [TongTienPhaiThanhToan], [TrangThaiHoaDon]) VALUES (9, 3, CAST(N'2022-09-01' AS Date), CAST(N'2022-10-09' AS Date), 10, 10, CAST(625000 AS Decimal(18, 0)), CAST(625000 AS Decimal(18, 0)), 1)
GO
INSERT [dbo].[tb_HoaDon] ([IdHoaDon], [id_HoaDon_Phong], [NgayXuatHoaDon], [KiHanThanhToan], [SoDien], [SoNuoc], [SoTienConLaiPhaiThanhToan], [TongTienPhaiThanhToan], [TrangThaiHoaDon]) VALUES (10, 3, CAST(N'2022-10-10' AS Date), CAST(N'2022-11-9' AS Date), 10, 10, CAST(625000 AS Decimal(18, 0)), CAST(625000 AS Decimal(18, 0)), 1)
GO
SET IDENTITY_INSERT [dbo].[tb_HoaDon] OFF
GO


SET IDENTITY_INSERT [dbo].[tb_LanThanhToan] ON 
GO
--Lần thanh toán của các hóa đơn phòng 1
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (1, 1, 1, CAST(625000 AS Decimal(18, 0)), CAST(N'2022-04-15' AS Date))
GO
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (2, 1, 2, CAST(250000 AS Decimal(18, 0)), CAST(N'2022-05-20' AS Date))
GO
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (3, 1, 3, CAST(400000 AS Decimal(18, 0)), CAST(N'2022-06-10' AS Date))
GO
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (4, 1, 4, CAST(2000 AS Decimal(18, 0)), CAST(N'2022-08-10' AS Date))
GO
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (5, 1, 5, CAST(500 AS Decimal(18, 0)), CAST(N'2022-09-10' AS Date))
GO
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (6, 1, 5, CAST(50000 AS Decimal(18, 0)), CAST(N'2022-09-10' AS Date))
GO

--Lần thanh toán của các hóa đơn phòng 2
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (7, 2, 7, CAST(625000 AS Decimal(18, 0)), CAST(N'2022-09-10' AS Date))
GO
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (8, 2, 8, CAST(25000 AS Decimal(18, 0)), CAST(N'2022-10-20' AS Date))
GO
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (9, 2, 8, CAST(25000 AS Decimal(18, 0)), CAST(N'2022-10-21' AS Date))
GO

--Lần thanh toán của các hóa đơn phòng 3
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (10, 3, 9, CAST(625000 AS Decimal(18, 0)), CAST(N'2022-09-10' AS Date))
GO
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (11, 3, 10, CAST(300000 AS Decimal(18, 0)), CAST(N'2022-10-20' AS Date))
GO
INSERT [dbo].[tb_LanThanhToan] ([IdLanThanhToan], [id_ThanhToan_KhachTro], [id_ThanhToan_HoaDon], [SoTienTra], [NgayThanhToan]) VALUES (12, 3, 10, CAST(325000 AS Decimal(18, 0)), CAST(N'2022-10-21' AS Date))
GO
SET IDENTITY_INSERT [dbo].[tb_LanThanhToan] OFF
GO

--Tạo Trigger thể hiện ràng buộc không được phép tạo 2 hóa đơn trùng tháng( trong vòng 30 ngày)
Create Trigger trg_KhongTonTaiHaiHoaDonTrongCungThang On tb_HoaDon
After Insert
As
	Begin
		Declare @NgayXuatHoaDonHienTai date,@IdPhongDuocThanhToan int,@IdHoaDonHienTai int,
				@NgayXuatHoaDonGanNhat date

		Select @NgayXuatHoaDonHienTai = ins.NgayXuatHoaDon,@IdPhongDuocThanhToan = ins.id_HoaDon_Phong,@IdHoaDonHienTai = ins.IdHoaDon
		From inserted ins

		--Nếu phòng đó có tồn tại ít nhất nhất một hóa đơn 
		If Exists (Select Top(1) * From tb_HoaDon Where id_HoaDon_Phong = @IdPhongDuocThanhToan And IdHoaDon != @IdHoaDonHienTai)
			Begin
				Select Top(1) @NgayXuatHoaDonGanNhat = NgayXuatHoaDon
				From tb_HoaDon hd 
				Where id_HoaDon_Phong = @IdPhongDuocThanhToan And IdHoaDon != @IdHoaDonHienTai
				Order By NgayXuatHoaDon Desc

				If DateDiff(Month,@NgayXuatHoaDonGanNhat,@NgayXuatHoaDonHienTai) < 1
					Begin
						Raiserror (N'Hóa đơn không hợp lệ vì, ngày xuất hóa đơn phải cách ngày xuất hóa đơn mới nhất hơn 1 tháng',16,1)
						Rollback
					End
			End
	End
Go