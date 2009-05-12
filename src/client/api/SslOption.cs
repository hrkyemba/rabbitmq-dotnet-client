// This source code is dual-licensed under the Apache License, version
// 2.0, and the Mozilla Public License, version 1.1.
//
// The APL v2.0:
//
//---------------------------------------------------------------------------
//   Copyright (C) 2007-2009 LShift Ltd., Cohesive Financial
//   Technologies LLC., and Rabbit Technologies Ltd.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//---------------------------------------------------------------------------
//
// The MPL v1.1:
//
//---------------------------------------------------------------------------
//   The contents of this file are subject to the Mozilla Public License
//   Version 1.1 (the "License"); you may not use this file except in
//   compliance with the License. You may obtain a copy of the License at
//   http://www.rabbitmq.com/mpl.html
//
//   Software distributed under the License is distributed on an "AS IS"
//   basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
//   License for the specific language governing rights and limitations
//   under the License.
//
//   The Original Code is The RabbitMQ .NET Client.
//
//   The Initial Developers of the Original Code are LShift Ltd,
//   Cohesive Financial Technologies LLC, and Rabbit Technologies Ltd.
//
//   Portions created before 22-Nov-2008 00:00:00 GMT by LShift Ltd,
//   Cohesive Financial Technologies LLC, or Rabbit Technologies Ltd
//   are Copyright (C) 2007-2008 LShift Ltd, Cohesive Financial
//   Technologies LLC, and Rabbit Technologies Ltd.
//
//   Portions created by LShift Ltd are Copyright (C) 2007-2009 LShift
//   Ltd. Portions created by Cohesive Financial Technologies LLC are
//   Copyright (C) 2007-2009 Cohesive Financial Technologies
//   LLC. Portions created by Rabbit Technologies Ltd are Copyright
//   (C) 2007-2009 Rabbit Technologies Ltd.
//
//   All Rights Reserved.
//
//   Contributor(s): ______________________________________.
//
//---------------------------------------------------------------------------
using System;
using System.Collections;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using RabbitMQ.Client.Impl;

namespace RabbitMQ.Client
{
    ///<summary>Represents a configurable SSL option, used
    ///in setting up an SSL connection.</summary>
    public class SslOption
    {

        private SslProtocols m_sslVersion = SslProtocols.Ssl3;

        ///<summary>Retrieve or set the path to client certificate.
        ///</summary>
        public SslProtocols SslVersion
        {
            get { return m_sslVersion; }
            set { m_sslVersion=value; }
        }

        private string m_cert;

        ///<summary>Retrieve or set the path to client certificate.
        ///</summary>
        public string Cert
        {
            get { return m_cert; }
            set { m_cert=value; }
        }

        ///<summary>Convenience read-only property to retrieve an X509CertificateCollection
        ///containing the client certificate</summary>
        public X509CertificateCollection CertCollection
        {
            get { 
                if(m_cert == "") {
                    return null;
                } else {
                    X509CertificateCollection c = new X509CertificateCollection();
                    c.Add(X509Certificate.CreateFromCertFile(m_cert));
                    return c;
                }
            }
        }

        private string m_serverName;

        ///<summary>Retrieve or set server's Canonical Name. This MUST match the CN
        ///on the Certificate else the SSL connection will fail</summary>
        public string ServerName
        {
            get { return m_serverName; }
            set { m_serverName=value; }
        }


        ///<summary>Construct an SslOption with just the server cannonical name.
        ///The Certificate path is set to an empty string
        ///</summary>
        public SslOption(string serverName): this(serverName, "")
        {
        }

        ///<summary>Construct an SslOption specifying both the server cannonical name
        ///and the client's certificate path.
        ///</summary>
        public SslOption(string serverName, string cert)
        {
            m_serverName= serverName;
            m_cert = cert;
        }

    }
}
