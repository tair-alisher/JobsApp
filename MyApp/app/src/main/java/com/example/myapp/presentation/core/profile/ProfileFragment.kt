package com.example.myapp.presentation.core.profile

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.navigation.fragment.findNavController
import androidx.preference.PreferenceManager
import com.example.myapp.R
import com.example.myapp.databinding.FragmentProfileBinding
import com.example.myapp.databinding.FragmentProfileUnauthorizedBinding

class ProfileFragment : Fragment() {
    private lateinit var binding: FragmentProfileBinding

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {

        context?.let { ctx ->
            PreferenceManager.getDefaultSharedPreferences(ctx).apply {
                if (!getBoolean(IS_LOGGED_IN_PREF_NAME, false)) {
                    val binding: FragmentProfileUnauthorizedBinding = FragmentProfileUnauthorizedBinding
                        .inflate(inflater, container, false)

                    binding.loginBtn.setOnClickListener {
                        findNavController().navigate(R.id.action_profileFragment_to_loginFragment)
                    }

                    return binding.root
                }
            }
        }

        binding = FragmentProfileBinding.inflate(inflater, container, false)

        return binding.root
    }

    companion object {
        const val IS_LOGGED_IN_PREF_NAME: String = "IS_USER_LOGGED_IN"
    }
}