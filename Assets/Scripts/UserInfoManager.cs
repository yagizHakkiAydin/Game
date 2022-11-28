using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Mail;



public class UserInfoManager : MonoBehaviour
{

    private string username;

    private string password;

    private string email;






    public Tuple<string , bool> CanThisUsernameBeRegisteredToServer( string name )
    {
        
        bool isUserNameAlreadyTaken = false; // ----------------will be updated from server

        Tuple<string,bool> resultTuple;


        if( isUserNameAlreadyTaken )
        {
            resultTuple = new Tuple<string,bool>( "Kullanıcı adı başkası tarafından kullanılıyor , lütfen yeni bir tane girin.", false );
        }
        else
        {
            resultTuple = this.IsUsernameLegal(name);
        }


        return resultTuple;
    }



    //Returns tuple
    //String is error message
    //Bool is result if given name can be registered
    public Tuple<string , bool> IsUsernameLegal( string name )
    {
        Tuple<string,bool> resultTuple;

        if( name.Length < 5 )
        {
            resultTuple = new Tuple<string,bool>( "Kullanıcı adı 5 karakterden daha kısa olamaz.", false );
        }
        else if( name.Length > 15 )
        {
            resultTuple = new Tuple<string,bool>( "Kullanıcı adı 15 karakterden daha uzun olamaz.", false );
        }
        else if( this.DoesUsernameConsistAnyForbiddenCharacter(name) )
        {
            resultTuple = new Tuple<string,bool>( "Kullanıcı adı sadece harf , rakam , \"-\" ya da \"_\" içerebilir.", false );
        }
        else
        {
            resultTuple = new Tuple<string,bool>("",true);
        }


        return resultTuple;
    }



    //Returns tuple
    //String is error message
    //Bool is result if given name can be registered
    public Tuple<string , bool> IsPasswordLegal( string pswrd )
    {
        Tuple<string,bool> resultTuple;

        if( pswrd.Length < 5 )
        {
            resultTuple = new Tuple<string,bool>( "Parolanız 6 karakterden daha kısa olamaz.", false );
        }
        else if( pswrd.Length > 15 )
        {
            resultTuple = new Tuple<string,bool>( "Parolanız 15 karakterden daha uzun olamaz.", false );
        }
        else
        {
            resultTuple = new Tuple<string,bool>("",true);
        }


        return resultTuple;
    }





    public void RegisterUser( string name , string password)
    {

    }

















    private bool DoesUsernameConsistAnyForbiddenCharacter( string username )
    {
        int nameLen = username.Length;


        for( int i=0 ; i<nameLen ; i++)
        {

            char ch = username[i];

            if( ch >= 'a' || ch <= 'z')
            {
                return false;
            }
            else if( ch >= 'A' || ch <= 'Z')
            {
                return false;
            }
             else if( ch >= '0' || ch <= '9')
            {
                return false;
            }
            else if( ch == '-' || ch == '_')
            {
                return false;
            }

        }

        return true;

    }




    public Tuple<string,bool> CanThisEmailBeRegisteredToServer(string email)
    {
        bool isEmailTaken = false;

        Tuple<string,bool> resultTuple;

        if( isEmailTaken ) 
        {
            resultTuple = new Tuple<string,bool>( "Bu e-mail ile kayıtlı bir kullanıcı zaten var.", false );
        }
        else if( !this.IsValidEmail(email) )
        {
            resultTuple = new Tuple<string,bool>( "Lütfen geçerli bir e-mail adresi girin.", false );
        }
        else
        {
            resultTuple = new Tuple<string,bool>( "", true );
        }



        return resultTuple;
    }



    public bool IsValidEmail(string email)
    {
        return true;
    }



}
