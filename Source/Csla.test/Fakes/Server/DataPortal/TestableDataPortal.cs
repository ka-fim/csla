﻿//-----------------------------------------------------------------------
// <copyright file="TestableDataPortal.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: https://cslanet.com
// </copyright>
// <summary>Basically this test class exposes protected DataPortal constructor overloads to the </summary>
//-----------------------------------------------------------------------
using System;
using Csla.Configuration;
using Csla.Server;
using Csla.Server.Dashboard;

namespace Csla.Testing.Business.DataPortal
{
  /// <summary>
  /// Basically this test class exposes protected DataPortal constructor overloads to the 
  /// Unit Testing System, allowing for a more fine-grained Unit Tests
  /// </summary>
  public class TestableDataPortal : Csla.Server.DataPortal
  {
    private IAuthorizeDataPortal _authorizer;

    public TestableDataPortal(
      ApplicationContext applicationContext,
      IDashboard dashboard,
      CslaOptions options,
      IAuthorizeDataPortal authorizer,
      InterceptorManager interceptors,
      IObjectFactoryLoader factoryLoader,
      IDataPortalActivator activator,
      IDataPortalExceptionInspector exceptionInspector,
      DataPortalExceptionHandler exceptionHandler
    ) : base(
      applicationContext,
      dashboard,
      options,
      authorizer,
      interceptors,
      factoryLoader,
      activator,
      exceptionInspector,
      exceptionHandler
    )
    {
      _authorizer = authorizer;
    }

    public static void Setup()
    {
    }

    public Type AuthProviderType
    {
      get
      {
        return _authorizer.GetType();
      }
    }

    public IAuthorizeDataPortal AuthProvider
    {
      get
      {
        return _authorizer;
      }
    }

    public bool NullAuthorizerUsed
    {
      get
      {
        return AuthProviderType == typeof(NullAuthorizer);
      }
    }

  }
}