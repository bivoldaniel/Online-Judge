﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Server.Interfaces;
using Server.Models;

namespace Server
{
    public class Judge
    {
        public delegate void TestEvaluatedEvent(object clock, EvaluationResultEventArgs args);
        public TestEvaluatedEvent TestEvaluated { get; set; }

        //public delegate void JudgeNotificationEvent(object clock, JudgeNotificationEventArgs args);
        //public JudgeNotificationEvent JudgeNotification { get; set; }

        private string EvaluationPath;
        private string GccCompilerPath;

        private DirectoryInfo EvaluationDirectory;
        private DirectoryInfo SubmissionsDirectory;
        private DirectoryInfo TestsDirectory;
        private DirectoryInfo WorkAreaDirectory;

        private Dictionary<int, string> submissionsPaths = new Dictionary<int, string>();
        private Dictionary<int, string> testsInPaths = new Dictionary<int, string>();
        private Dictionary<int, string> testsOkPaths = new Dictionary<int, string>();
        private Dictionary<int, string> testsOkValues = new Dictionary<int, string>();

        private CheckSubmission worker;
        private IVerifier verifier;
        private Repository repository;

        public Judge(string evaluationPath, string gccCompilerPath, Repository repository)
        {
            EvaluationPath = evaluationPath;
            GccCompilerPath = gccCompilerPath;
            this.repository = repository;
        }

        public void Evaluate(SubmissionJson submission )
        {
            Console.WriteLine("Evaluation Started");

            ICompiler compiler = CompilerFactory.GetCompiler(submission.Language);
            string executablePath = String.Empty;
            string testsFolder = String.Empty;

            if (compiler != null)
            {
                if (compiler.Compile(submissionsPaths[submission.Id], out executablePath))
                {
                    testsFolder = TestsDirectory.FullName + "\\" + submission.SubmissionProblemId + "\\";
                    File.Copy(executablePath, WorkAreaDirectory.FullName + "\\" + submission.SubmissionProblemId + Constants.exe, true);


                    foreach(var test in repository.Tests)
                    {

                    }
                }
            }

        }
    }
}
