# Nhap truc tiep tren may; khong gui mat khau vao chat hoac Git.
$ErrorActionPreference = 'Stop'
Write-Host 'Cau hinh Gmail gui OTP cho Quan Ly Giang Vien'
Write-Host 'Dung mat khau ung dung Google, khong dung mat khau dang nhap Gmail.'
Write-Host 'Cau hinh duoc luu trong bien moi truong tai khoan Windows hien tai.'
$sender = (Read-Host 'Dia chi Gmail gui ma').Trim()
try { $address = [System.Net.Mail.MailAddress]::new($sender) } catch { throw 'Dia chi email khong hop le.' }
if ($address.Address -ne $sender) { throw 'Chi nhap dia chi email, khong kem ten hien thi.' }
$secret = Read-Host 'Mat khau ung dung Gmail (ky tu se duoc che)' -AsSecureString
$pointer = [IntPtr]::Zero
try {
    $pointer = [Runtime.InteropServices.Marshal]::SecureStringToBSTR($secret)
    $value = [Runtime.InteropServices.Marshal]::PtrToStringBSTR($pointer).Replace(' ', '').Trim()
    if ($value.Length -ne 16) { throw 'Mat khau ung dung Google can 16 ky tu.' }
    [Environment]::SetEnvironmentVariable('QLGV_GMAIL_USER', $sender, 'User')
    [Environment]::SetEnvironmentVariable('QLGV_GMAIL_APP_PASSWORD', $value, 'User')
    Write-Host 'Da luu cau hinh. Khong co email nao duoc gui trong buoc nay.' -ForegroundColor Green
} finally {
    if ($pointer -ne [IntPtr]::Zero) { [Runtime.InteropServices.Marshal]::ZeroFreeBSTR($pointer) }
    $value = $null
    $secret.Dispose()
}
Read-Host 'Nhan Enter de dong'
