'Created by: Mukesh singh
'Created on: 02-Jan-2009
'Usage:-This Class is used for encrypting or decrypting the file or string. 
'Modified by: Mukesh singh on 07-jan-2009
'--------------------------------------

#Region "Imports"
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
#End Region

Public Class clsDesCrypto
#Region "Variable Declaration"
    Private Const passPhrase As String = "t2194562980t"
    Private Const saltValue As String = "p0937654316p"
    Private Const hashAlgorithm As String = "MD5"
    Private Const passwordIterations As Integer = 2
    Private Const initVector As String = "@1B2c3D4e5F6g7H8"
    Private Const keySize As Integer = 256

#Region ".....Variable Declaration for Exception Handling"
    Private m_strClassFormName As String = "clsDesCrypto"
    Private m_strMethodFunctionName As String = ""
    Private m_strSubMethodFunctionName As String = ""
    Private m_strSimplifiedExceptionMsg As String = ""
#End Region
#End Region

#Region "Function"
    Public Shared Function fnEncryptR(ByVal plainText As String) As String
        Try
            Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
            Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)

            Dim password As PasswordDeriveBytes = New PasswordDeriveBytes(passPhrase, _
                                               saltValueBytes, _
                                               hashAlgorithm, _
                                               passwordIterations)

            Dim keyBytes As Byte() = password.GetBytes(keySize / 8)

            ' Create uninitialized Rijndael encryption object.
            Dim symmetricKey As RijndaelManaged = New RijndaelManaged

            symmetricKey.Mode = CipherMode.CBC
            symmetricKey.Padding = PaddingMode.PKCS7

            ' Generate encryptor from the existing key bytes and initialization 
            ' vector. Key size will be defined based on the number of the key 
            ' bytes.
            Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

            ' Define memory stream which will be used to hold encrypted data.
            Dim memoryStream As MemoryStream = New MemoryStream

            ' Define cryptographic stream (always use Write mode for encryption).
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, _
                                            encryptor, _
                                            CryptoStreamMode.Write)
            ' Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)

            ' Finish encrypting.
            cryptoStream.FlushFinalBlock()

            ' Convert our encrypted data from a memory stream into a byte array.
            Dim cipherTextBytes As Byte() = memoryStream.ToArray()

            ' Close both streams.
            memoryStream.Close()
            cryptoStream.Close()

            ' Convert encrypted data into a base64-encoded string.
            Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)

            ' Return encrypted string.
            Return cipherText
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fnDecryptR(ByVal cipherText As String) As String
        Try
            If cipherText = "" Then Return cipherText
            ' Convert strings defining encryption key characteristics into byte
            ' arrays. Let us assume that strings only contain ASCII codes.
            ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
            ' encoding.
            Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
            ' Convert our ciphertext into a byte array.
            Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)

            ' First, we must create a password, from which the key will be 
            ' derived. This password will be generated from the specified 
            ' passphrase and salt value. The password will be created using
            ' the specified hash algorithm. Password creation can be done in
            ' several iterations.
            Dim password As PasswordDeriveBytes = New PasswordDeriveBytes(passPhrase, _
                                               saltValueBytes, _
                                               hashAlgorithm, _
                                               passwordIterations)

            ' Use the password to generate pseudo-random bytes for the encryption
            ' key. Specify the size of the key in bytes (instead of bits).
            Dim keyBytes As Byte() = password.GetBytes(keySize / 8)
            'Dim keyBytes As Byte() = {23, 39, 79, 67, 81, 92, 53, 62, 23, 53, 31, 125, 128, 43, 11, 23, 48, 97, 56, 11, 5, 1, 65, 132}

            ' Create uninitialized Rijndael encryption object.
            Dim symmetricKey As RijndaelManaged = New RijndaelManaged

            ' It is reasonable to set encryption mode to Cipher Block Chaining
            ' (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC
            symmetricKey.Padding = PaddingMode.PKCS7

            ' Generate decryptor from the existing key bytes and initialization 
            ' vector. Key size will be defined based on the number of the key 
            ' bytes.
            Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

            ' Define memory stream which will be used to hold encrypted data.
            Dim memoryStream As MemoryStream = New MemoryStream(cipherTextBytes)

            ' Define memory stream which will be used to hold encrypted data.
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, _
                                            decryptor, _
                                            CryptoStreamMode.Read)

            ' Since at this point we don't know what the size of decrypted data
            ' will be, allocate the buffer long enough to hold ciphertext;
            ' plaintext is never longer than ciphertext.
            Dim plainTextBytes As Byte()
            ReDim plainTextBytes(cipherTextBytes.Length)

            ' Start decrypting.
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, _
                                                   0, _
                                                   plainTextBytes.Length)

            ' Close both streams.
            memoryStream.Close()
            cryptoStream.Close()

            ' Convert decrypted data into a string. 
            ' Let us assume that the original plaintext string was UTF8-encoded.
            Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, _
                                                0, _
                                                decryptedByteCount)

            ' Return decrypted string.
            Return plainText
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class

